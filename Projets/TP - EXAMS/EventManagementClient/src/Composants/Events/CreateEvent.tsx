import React, { useEffect, useState } from "react";
import { URL_API } from "../../Others/Constantes.ts";
import { CategoryDto, LocationDto } from "../../Others/Interface.ts";
import { fetchCategories, fetchLocations } from "../../Others/utils.ts";

const CreateEvent: React.FC = () => {
    const [locations, setLocations] = useState<LocationDto | null>(null);
    const [categories, setCategories] = useState<CategoryDto | null>(null);
    const [form, setForm] = useState({
        name: "",
        description: "",
        startDate: "",
        endDate: "",
        locationId: 0,
        categoryId: 0,
        registrationDate: new Date().toISOString(),
        attendanceStatus: "",
    });

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement>) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        try {
            const response = await fetch(`${URL_API}/Event`, {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(form),
            });
            if (!response.ok) throw new Error("Erreur lors de la création de l'événement");
            alert("🎉 Événement créé avec succès !");
            window.location.reload();
        } catch (error) {
            console.error(error);
            alert("❌ Une erreur est survenue lors de la création de l'événement.");
        }
    };

    useEffect(() => {
        fetchLocations()
            .then(data => setLocations(data))
            .catch(error => console.error("Error fetching locations:", error));

        fetchCategories()
            .then(data => setCategories(data))
            .catch(error => console.error("Error fetching categories:", error));
    }, []);

    return (
        <form onSubmit={handleSubmit} className="bg-white p-8 rounded-2xl shadow-xl space-y-6 max-w-2xl mx-auto">
            <h2 className="text-3xl font-bold text-gray-800 text-center mb-6">Créer un Événement</h2>

            {/* Nom */}
            <div className="relative">
                <input
                    type="text"
                    name="name"
                    value={form.name}
                    onChange={handleChange}
                    required
                    className="peer w-full border-b-2 border-gray-300 text-gray-900 placeholder-transparent focus:outline-none focus:border-blue-500 pb-3"
                    placeholder="Titre de l'événement"
                />
                <label className="absolute left-0 -top-3.5 text-gray-600 text-sm transition-all peer-placeholder-shown:text-base peer-placeholder-shown:text-gray-400 peer-placeholder-shown:top-2 peer-focus:-top-3.5 peer-focus:text-sm peer-focus:text-gray-600">
                    Titre de l'événement
                </label>
            </div>

            {/* Description */}
            <div className="relative">
                <textarea
                    name="description"
                    value={form.description}
                    onChange={handleChange}
                    required
                    rows={3}
                    className="peer w-full border-b-2 border-gray-300 text-gray-900 placeholder-transparent focus:outline-none focus:border-blue-500"
                    placeholder="Description"
                />
                <label className="absolute left-0 -top-3.5 text-gray-600 text-sm transition-all peer-placeholder-shown:text-base peer-placeholder-shown:text-gray-400 peer-placeholder-shown:top-2 peer-focus:-top-3.5 peer-focus:text-sm peer-focus:text-gray-600">
                    Description
                </label>
            </div>

            {/* Dates */}
            <div className="grid grid-cols-2 gap-4">
                <div className="relative">
                    <input
                        type="date"
                        name="startDate"
                        value={form.startDate}
                        onChange={handleChange}
                        required
                        className="peer w-full border-b-2 border-gray-300 text-gray-900 placeholder-transparent focus:outline-none focus:border-blue-500"
                        placeholder="Date de début"
                    />
                    <label className="absolute left-0 -top-3.5 text-gray-600 text-sm transition-all peer-placeholder-shown:top-2 peer-focus:-top-3.5 peer-focus:text-sm peer-focus:text-gray-600">
                        Date de début
                    </label>
                </div>
                <div className="relative">
                    <input
                        type="date"
                        name="endDate"
                        value={form.endDate}
                        onChange={handleChange}
                        required
                        className="peer w-full border-b-2 border-gray-300 text-gray-900 placeholder-transparent focus:outline-none focus:border-blue-500"
                        placeholder="Date de fin"
                    />
                    <label className="absolute left-0 -top-3.5 text-gray-600 text-sm transition-all peer-placeholder-shown:top-2 peer-focus:-top-3.5 peer-focus:text-sm peer-focus:text-gray-600">
                        Date de fin
                    </label>
                </div>
            </div>

            {/* Attendance Status */}
            <div className="relative">
                <input
                    type="text"
                    name="attendanceStatus"
                    value={form.attendanceStatus}
                    onChange={handleChange}
                    required
                    className="peer w-full border-b-2 border-gray-300 text-gray-900 placeholder-transparent focus:outline-none focus:border-blue-500 p-2"
                    placeholder="Statut de présence"
                />
                <label className="absolute left-0 -top-3.5 text-gray-600 text-sm transition-all peer-placeholder-shown:top-2 peer-focus:-top-3.5 peer-focus:text-sm peer-focus:text-gray-600">
                    Statut de présence
                </label>
            </div>

            {/* Lieux */}
            <div>
                <label className="block mb-1 text-gray-700 font-medium">Lieu</label>
                <select
                    name="locationId"
                    value={form.locationId}
                    onChange={handleChange}
                    required
                    className="w-full border-b-2 border-gray-300 text-gray-900 focus:outline-none focus:border-blue-500 bg-transparent"
                >
                    <option value={0} disabled>Sélectionner un lieu</option>
                    {locations?.$values.map(location => (
                        <option key={location.id} value={location.id}>
                            {location.name}
                        </option>
                    ))}
                </select>
            </div>

            {/* Catégories */}
            <div>
                <label className="block mb-1 text-gray-700 font-medium">Catégorie</label>
                <select
                    name="categoryId"
                    value={form.categoryId}
                    onChange={handleChange}
                    required
                    className="w-full border-b-2 border-gray-300 text-gray-900 focus:outline-none focus:border-blue-500 bg-transparent"
                >
                    <option value={0} disabled>Sélectionner une catégorie</option>
                    {categories?.$values.map(category => (
                        <option key={category.id} value={category.id}>
                            {category.name}
                        </option>
                    ))}
                </select>
            </div>

            {/* Bouton Submit */}
            <div className="text-center pt-4">
                <button
                    type="submit"
                    className="bg-blue-600 text-white py-2 px-6 rounded-full hover:bg-blue-700 transition duration-300"
                >
                    Créer l'événement
                </button>
            </div>
        </form>
    );
};

export default CreateEvent;
