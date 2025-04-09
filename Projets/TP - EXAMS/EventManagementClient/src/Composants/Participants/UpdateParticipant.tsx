import React, { useEffect, useState } from "react";

interface UpdateParticipantProps {
    participantId: number;
}

const UpdateParticipant: React.FC<UpdateParticipantProps> = ({ participantId }) => {
    const [form, setForm] = useState({
        firstName: "",
        lastName: "",
        email: "",
        company: "",
        jobTitle: ""
    });

    useEffect(() => {
        fetch(`/api/Participant/${participantId}`)
            .then(res => res.json())
            .then(setForm)
            .catch(console.error);
    }, [participantId]);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        try {
            const res = await fetch(`/api/Participant/${participantId}`, {
                method: "PUT",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(form),
            });
            if (!res.ok) throw new Error("Erreur lors de la mise à jour");
            alert("Participant mis à jour !");
        } catch (err) {
            console.error(err);
        }
    };

    return (
        <form onSubmit={handleSubmit} className="bg-white p-6 rounded-xl shadow-md space-y-4">
            <h2 className="text-2xl font-bold text-gray-800">Modifier le Participant</h2>
            <input name="firstName" placeholder="Prénom" value={form.firstName} onChange={handleChange} className="w-full p-2 border rounded" required />
            <input name="lastName" placeholder="Nom" value={form.lastName} onChange={handleChange} className="w-full p-2 border rounded" required />
            <input name="email" type="email" placeholder="Email" value={form.email} onChange={handleChange} className="w-full p-2 border rounded" required />
            <input name="company" placeholder="Entreprise" value={form.company} onChange={handleChange} className="w-full p-2 border rounded" required />
            <input name="jobTitle" placeholder="Poste" value={form.jobTitle} onChange={handleChange} className="w-full p-2 border rounded" required />
            <button type="submit" className="bg-green-600 text-white px-4 py-2 rounded">Mettre à jour</button>
        </form>
    );
};

export default UpdateParticipant;
