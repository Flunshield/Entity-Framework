import React, { useEffect, useState } from "react";
import { URL_API } from "../../Others/Constantes.ts";
import {CategoryDto, EventDto, LocationDto} from "../../Others/Interface.ts";
import {fetchCategories, fetchLocations, getAllEvent} from "../../Others/utils.ts";

const UpdateEvent: React.FC = () => {
    const [events, setEvents] = useState<EventDto | null>(null);
    const [locations, setLocations] = useState<LocationDto | null>(null);
    const [eventId, setEventId] = useState<number | null>(null);
    const [category, setCategories] = useState<CategoryDto | null>(null);
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
        setForm({ ...form, [e.target.name]: e.target.value });
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
        // Récupérer tous les événements
        getAllEvent()
            .then(data => setEvents(data))
            .catch(error => console.error("Error fetching events:", error));

        fetchLocations()
            .then(data => setLocations(data))
            .catch(error => console.error("Error fetching locations:", error));

        fetchCategories()
            .then(data => setCategories(data))
            .catch(error => console.error("Error fetching categories:", error));
    }, []);

    useEffect(() => {
        if (eventId !== null) {
            // Récupérer les détails de l'événement à mettre à jour
            fetch(`${URL_API}/Event/${eventId}`)
                .then((res) => res.json())
                .then((data) => {
                    console.log(data)
                        const event = data
                    console.log(data)
                        setForm({
                            id: event.id,
                            name: event.name,
                            description: event.description,
                            startDate: event.startDate,
                            endDate: event.endDate,
                            attendanceStatus: event.attendanceStatus,
                            locationId: event.locationId,
                            categoryId: event.categoryId,
                        });
                })
                .catch(console.error);
        }
    }, [eventId]);

    return (
        <form onSubmit={handleSubmit} className="bg-white p-6 rounded-xl shadow-md space-y-4">
            <h2 className="text-2xl font-bold text-gray-800">Modifier l'Événement</h2>

            {/* Sélecteur d'événements */}
            <div>
                <label htmlFor="eventId" className="block text-sm font-medium text-gray-700">
                    Sélectionner un événement
                </label>
                <select
                    name="eventId"
                    value={eventId || ""}
                    onChange={(e) => setEventId(Number(e.target.value))}
                    className="w-full p-2 border rounded"
                    required
                >
                    <option value={""} disabled>Sélectionner un événement</option>
                    {events?.$values.map((event) => (
                        <option key={event.id} value={event.id}>
                            {event.name}
                        </option>
                    ))}
                </select>
            </div>

            {/* Formulaire de mise à jour de l'événement */}
            <input
                name="name"
                placeholder="name"
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
                value={form.startDate ? form.startDate.split("T")[0] : ""}
                onChange={handleChange}
                className="w-full p-2 border rounded"
                required
            />
            <input
                name="endDate"
                type="date"
                value={form.endDate ? form.endDate.split("T")[0] : ""}
                onChange={handleChange}
                className="w-full p-2 border rounded"
                required
            />
            <input
                name="attendanceStatus"
                placeholder="Statut"
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
                    Sélectionner une categorie
                </label>
                <select
                    name="categoryId"
                    value={form.categoryId}
                    onChange={handleChange}
                    className="w-full p-2 border rounded"
                    required
                >
                    <option value={0} disabled>Sélectionner un lieu</option>
                    {category?.$values.map((categorie) => (
                        <option key={categorie.id} value={categorie.id}>
                            {categorie.name} - {categorie.description}
                        </option>
                    ))}
                </select>
            </div>

            <button type="submit" onClick={handleSubmit} className="bg-green-600 text-white px-4 py-2 rounded">
                Mettre à jour
            </button>
        </form>
    );
};

export default UpdateEvent;
