import React, { useState } from "react";

const CreateParticipant: React.FC = () => {
    const [form, setForm] = useState({
        firstName: "",
        lastName: "",
        email: "",
        company: "",
        jobTitle: ""
    });

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        try {
            const res = await fetch("/api/Participant", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(form),
            });
            if (!res.ok) throw new Error("Erreur lors de la création du participant");
            alert("Participant créé !");
        } catch (err) {
            console.error(err);
        }
    };

    return (
        <form onSubmit={handleSubmit} className="bg-white p-6 rounded-xl shadow-md space-y-4">
            <h2 className="text-2xl font-bold text-gray-800">Ajouter un Participant</h2>
            <input name="firstName" placeholder="Prénom" value={form.firstName} onChange={handleChange} className="w-full p-2 border rounded" required />
            <input name="lastName" placeholder="Nom" value={form.lastName} onChange={handleChange} className="w-full p-2 border rounded" required />
            <input name="email" type="email" placeholder="Email" value={form.email} onChange={handleChange} className="w-full p-2 border rounded" required />
            <input name="company" placeholder="Entreprise" value={form.company} onChange={handleChange} className="w-full p-2 border rounded" required />
            <input name="jobTitle" placeholder="Poste" value={form.jobTitle} onChange={handleChange} className="w-full p-2 border rounded" required />
            <button type="submit" className="bg-blue-600 text-white px-4 py-2 rounded">Créer</button>
        </form>
    );
};

export default CreateParticipant;
