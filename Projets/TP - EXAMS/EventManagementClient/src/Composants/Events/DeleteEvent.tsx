import React, { useEffect, useState } from "react";
import { EventDto } from "../../Others/Interface.ts";
import { getAllEvent } from "../../Others/utils.ts";
import {URL_API} from "../../Others/Constantes.ts";

const DeleteEvent: React.FC = () => {
    const [eventId, setEventId] = useState<number | null>(null);
    const [events, setEvents] = useState<EventDto | null>(null);

    const handleDelete = async () => {
        if (eventId !== null && confirm("Êtes-vous sûr de vouloir supprimer cet événement ?")) {
            try {
                const response = await fetch(`${URL_API}/Event/${eventId}`, {
                    method: "DELETE",
                });
                if (!response.ok) throw new Error("Erreur lors de la suppression de l'événement");
                alert("Événement supprimé avec succès !");
                window.location.reload();
                // Optionally reload events after delete
                getAllEvent().then(data => setEvents(data)).catch(console.error);
            } catch (error) {
                console.error("Erreur lors de la suppression :", error);
            }
        }
    };

    useEffect(() => {
        // Récupérer tous les événements
        getAllEvent()
            .then(data => setEvents(data))
            .catch(error => console.error("Error fetching events:", error));
    }, []);

    return (
        <div className="bg-white p-6 rounded-xl shadow-md space-y-4">
            <h2 className="text-2xl font-bold text-gray-800">Supprimer un événement</h2>

            {/* Sélecteur d'événements */}
            <div>
                <label htmlFor="eventId" className="block text-sm font-medium text-gray-700">
                    Sélectionner un événement à supprimer
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

            {/* Bouton de suppression */}
            <button
                onClick={handleDelete}
                className="bg-red-600 text-white px-4 py-2 rounded mt-4"
                disabled={!eventId}
            >
                Supprimer l'Événement
            </button>
        </div>
    );
};

export default DeleteEvent;
