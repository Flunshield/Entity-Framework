import React, { useEffect, useState } from "react";
import { URL_API } from "../../Others/Constantes.ts";
import { CategoryDto, EventDto, LocationDto } from "../../Others/Interface.ts";
import { fetchCategories, fetchLocations, getAllEvent } from "../../Others/utils.ts";

const UpdateEvent: React.FC = () => {
    const [events, setEvents] = useState<EventDto | null>(null);
    const [locations, setLocations] = useState<LocationDto | null>(null);
    const [categories, setCategories] = useState<CategoryDto | null>(null);
    const [eventId, setEventId] = useState<number | null>(null);

    const [form, setForm] = useState({
        name: "",
        description: "",
        startDate: "",
        endDate: "",
        attendanceStatus: "",
        locationId: 0,
        categoryId: 0,
        id: null
    });

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement>) => {
        const { name, value } = e.target;
        setForm({ ...form, [name]: value });
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        try {
            const response = await fetch(`${URL_API}/Event/${eventId}`, {
                method: "PUT",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(form),
            });
            if (!response.ok) throw new Error("Erreur lors de la mise à jour de l'événement");
            alert("Événement mis à jour avec succès !");
            window.location.reload();
        } catch (error) {
            console.error(error);
        }
    };

    useEffect(() => {
        getAllEvent().then(setEvents).catch(console.error);
        fetchLocations().then(setLocations).catch(console.error);
        fetchCategories().then(setCategories).catch(console.error);
    }, []);

    useEffect(() => {
        if (eventId !== null) {
            fetch(`${URL_API}/Event/${eventId}`)
                .then((res) => res.json())
                .then((event) => {
                    const eventData = event;
                    setForm({
                        id: eventData.id,
                        name: eventData.name,
                        description: eventData.description,
                        startDate: eventData.startDate,
                        endDate: eventData.endDate,
                        attendanceStatus: eventData.attendanceStatus,
                        locationId: eventData.locationId,
                        categoryId: eventData.categoryId,
                    });
                })
                .catch(console.error);
        }
    }, [eventId]);

    return (
        <form onSubmit={handleSubmit} className="bg-white p-8 rounded-2xl shadow-xl space-y-6 max-w-xl mx-auto">
            <h2 className="text-3xl font-bold text-gray-800 text-center">Modifier un Événement</h2>

            {/* Event selector */}
            <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Événement à modifier</label>
                <select
                    value={eventId ?? ""}
                    onChange={(e) => setEventId(Number(e.target.value))}
                    className="w-full border border-gray-300 rounded-lg p-2"
                >
                    <option value="">Sélectionnez un événement</option>
                    {events?.$values.map((event) => (
                        <option key={event.id} value={event.id}>
                            {event.name}
                        </option>
                    ))}
                </select>
            </div>

            {/* Input fields */}
            <div className="space-y-4">
                <input
                    type="text"
                    name="name"
                    placeholder="Nom de l'événement"
                    value={form.name}
                    onChange={handleChange}
                    className="w-full border border-gray-300 rounded-lg p-2"
                />
                <textarea
                    name="description"
                    placeholder="Description"
                    value={form.description}
                    onChange={handleChange}
                    className="w-full border border-gray-300 rounded-lg p-2"
                />
                <input
                    type="date"
                    name="startDate"
                    value={form.startDate}
                    onChange={handleChange}
                    className="w-full border border-gray-300 rounded-lg p-2"
                />
                <input
                    type="date"
                    name="endDate"
                    value={form.endDate}
                    onChange={handleChange}
                    className="w-full border border-gray-300 rounded-lg p-2"
                />
                <input
                    type="text"
                    name="attendanceStatus"
                    placeholder="Statut de présence"
                    value={form.attendanceStatus}
                    onChange={handleChange}
                    className="w-full border border-gray-300 rounded-lg p-2"
                />
            </div>

            {/* Select Location */}
            <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Lieu</label>
                <select
                    name="locationId"
                    value={form.locationId}
                    onChange={handleChange}
                    className="w-full border border-gray-300 rounded-lg p-2"
                >
                    <option value="">Sélectionnez un lieu</option>
                    {locations?.$values.map((location) => (
                        <option key={location.id} value={location.id}>
                            {location.name}
                        </option>
                    ))}
                </select>
            </div>

            {/* Select Category */}
            <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Catégorie</label>
                <select
                    name="categoryId"
                    value={form.categoryId}
                    onChange={handleChange}
                    className="w-full border border-gray-300 rounded-lg p-2"
                >
                    <option value="">Sélectionnez une catégorie</option>
                    {categories?.$values.map((category) => (
                        <option key={category.id} value={category.id}>
                            {category.name}
                        </option>
                    ))}
                </select>
            </div>

            {/* Submit Button */}
            <button
                type="submit"
                className="w-full bg-blue-600 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded-lg transition duration-300"
            >
                Mettre à jour l'événement
            </button>
        </form>
    );
};

export default UpdateEvent;
