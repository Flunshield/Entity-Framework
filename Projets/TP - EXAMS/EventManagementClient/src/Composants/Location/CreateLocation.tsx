import React, { useState } from "react";

const CreateLocation: React.FC = () => {
    const [form, setForm] = useState({
        name: "",
        address: "",
        city: "",
        country: "",
        capacity: 0
    });

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const value = e.target.name === "capacity" ? Number(e.target.value) : e.target.value;
        setForm({ ...form, [e.target.name]: value });
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        try {
            const response = await fetch("/api/Location", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(form),
            });
            if (!response.ok) throw new Error("Erreur lors de la création de l'emplacement");
            alert("Emplacement créé avec succès !");
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <form onSubmit={handleSubmit} className="bg-white p-6 rounded-xl shadow-md space-y-4">
            <h2 className="text-2xl font-bold text-gray-800">Créer un Emplacement</h2>
            <input name="name" placeholder="Nom" value={form.name} onChange={handleChange} className="w-full p-2 border rounded" required />
            <input name="address" placeholder="Adresse" value={form.address} onChange={handleChange} className="w-full p-2 border rounded" required />
            <input name="city" placeholder="Ville" value={form.city} onChange={handleChange} className="w-full p-2 border rounded" required />
            <input name="country" placeholder="Pays" value={form.country} onChange={handleChange} className="w-full p-2 border rounded" required />
            <input name="capacity" type="number" placeholder="Capacité" value={form.capacity} onChange={handleChange} className="w-full p-2 border rounded" required />
            <button type="submit" className="bg-blue-600 text-white px-4 py-2 rounded">Créer</button>
        </form>
    );
};

export default CreateLocation;
