import React, { useEffect, useState } from "react";

interface UpdateLocationProps {
    locationId: number;
}

const UpdateLocation: React.FC<UpdateLocationProps> = ({ locationId }) => {
    const [form, setForm] = useState({
        name: "",
        address: "",
        city: "",
        country: "",
        capacity: 0
    });

    useEffect(() => {
        fetch(`/api/Location/${locationId}`)
            .then(res => res.json())
            .then(data => setForm(data))
            .catch(console.error);
    }, [locationId]);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const value = e.target.name === "capacity" ? Number(e.target.value) : e.target.value;
        setForm({ ...form, [e.target.name]: value });
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        try {
            const response = await fetch(`/api/Location/${locationId}`, {
                method: "PUT",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(form),
            });
            if (!response.ok) throw new Error("Erreur lors de la mise à jour de l'emplacement");
            alert("Emplacement mis à jour avec succès !");
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <form onSubmit={handleSubmit} className="bg-white p-6 rounded-xl shadow-md space-y-4">
            <h2 className="text-2xl font-bold text-gray-800">Modifier l'Emplacement</h2>
            <input name="name" placeholder="Nom" value={form.name} onChange={handleChange} className="w-full p-2 border rounded" required />
            <input name="address" placeholder="Adresse" value={form.address} onChange={handleChange} className="w-full p-2 border rounded" required />
            <input name="city" placeholder="Ville" value={form.city} onChange={handleChange} className="w-full p-2 border rounded" required />
            <input name="country" placeholder="Pays" value={form.country} onChange={handleChange} className="w-full p-2 border rounded" required />
            <input name="capacity" type="number" placeholder="Capacité" value={form.capacity} onChange={handleChange} className="w-full p-2 border rounded" required />
            <button type="submit" className="bg-green-600 text-white px-4 py-2 rounded">Mettre à jour</button>
        </form>
    );
};

export default UpdateLocation;
