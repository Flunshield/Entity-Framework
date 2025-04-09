import React, { useEffect, useState } from "react";
import { URL_API } from "../../Others/Constantes.ts";
import {CategoryDto, LocationDto} from "../../Others/Interface.ts";
import {fetchCategories, fetchLocations} from "../../Others/utils.ts";

const CreateEvent: React.FC = () => {
    const [locations, setLocations] = useState<LocationDto | null>(null);
    const [categories, setCategories] = useState<CategoryDto | null>(null);
    const [form, setForm] = useState({
        name: "",
        description: "",
        startDate: "",
        endDate: "",
        locationId: 1,
        categoryId:1,
        registrationDate: new Date(),
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
            alert("Événement créé avec succès !");
            window.location.reload();
        } catch (error) {
            console.error(error);
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
        <form onSubmit={handleSubmit} className="bg-white p-6 rounded-xl shadow-md space-y-4">
            <h2 className="text-2xl font-bold text-gray-800">Créer un Événement</h2>
            <input
                name="name"
                placeholder="Titre"
                value={form.name}
                onChange={handleChange}
                className="w-full p-2 border rounded"
                required
            />
            <textarea
                name="description"
                placeholder="Description"
                value={form.description}
                onChange={handleChange}
                className="w-full p-2 border rounded"
                required
            />
            <input
                name="startDate"
                type="date"
                value={form.startDate}
                onChange={handleChange}
                className="w-full p-2 border rounded"
                required
            />
            <input
                name="endDate"
                type="date"
                value={form.endDate}
                onChange={handleChange}
                className="w-full p-2 border rounded"
                required
            />
            <input
                name="attendanceStatus"
                placeholder="attendanceStatus"
                value={form.attendanceStatus}
                onChange={handleChange}
                className="w-full p-2 border rounded"
                required
            />

            <div>
                <label htmlFor="locationId" className="block text-sm font-medium text-gray-700">
                    Sélectionner un Lieu
                </label>
                <select
                    name="locationId"
                    value={form.locationId}
                    onChange={handleChange}
                    className="w-full p-2 border rounded"
                    required
                >
                    <option value={0} disabled>Sélectionner un lieu</option>
                    {locations?.$values.map((location) => (
                        <option key={location.id} value={location.id}>
                            {location.name} - {location.address}
                        </option>
                    ))}
                </select>
            </div>

            <div>
                <label htmlFor="categoryId" className="block text-sm font-medium text-gray-700">
                    Sélectionner une catégorie
                </label>
                <select
                    name="categoryId"
                    value={form.categoryId}
                    onChange={handleChange}
                    className="w-full p-2 border rounded"
                    required
                >
                    <option value={0} disabled>Sélectionner un lieu</option>
                    {categories?.$values.map((location) => (
                        <option key={location.id} value={location.id}>
                            {location.name} - {location.description}
                        </option>
                    ))}
                </select>
            </div>

            <button type="submit" className="bg-blue-600 text-white px-4 py-2 rounded">
                Créer
            </button>
        </form>
    );
};

export default CreateEvent;
