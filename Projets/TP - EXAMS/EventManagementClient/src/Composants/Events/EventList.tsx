import React, { useEffect, useState } from "react";
import { EventDto } from "../../Others/Interface.ts";
import { getAllEvent } from "../../Others/utils.ts";
import { URL_API } from "../../Others/Constantes.ts";

const EventList: React.FC = () => {
    const [events, setEvents] = useState<EventDto | null>(null);

    const fetchEvents = async () => {
        try {
            const data = await getAllEvent();
            setEvents(data);
        } catch (error) {
            console.error("Erreur lors de la récupération des événements :", error);
        }
    };

    const handleDelete = async (eventId: number) => {
        if (confirm("Êtes-vous sûr de vouloir supprimer cet événement ?")) {
            try {
                const response = await fetch(`${URL_API}/Event/${eventId}`, {
                    method: "DELETE",
                });
                if (!response.ok) throw new Error("Erreur lors de la suppression de l'événement");
                alert("Événement supprimé avec succès !");
                fetchEvents(); // Rafraîchir la liste
            } catch (error) {
                console.error("Erreur lors de la suppression :", error);
            }
        }
    };

    useEffect(() => {
        fetchEvents();
    }, []);

    return (
        <div className="bg-white p-8 rounded-2xl shadow-xl space-y-6 max-w-4xl mx-auto">
            <h2 className="text-3xl font-bold text-gray-800 text-center">Liste des Événements</h2>

            {events?.$values.length ? (
                <table className="min-w-full table-auto border-collapse">
                    <thead className="bg-gray-100">
                    <tr>
                        <th className="py-3 px-6 text-left text-gray-600">Nom</th>
                        <th className="py-3 px-6 text-left text-gray-600">Description</th>
                        <th className="py-3 px-6 text-left text-gray-600">Date de début</th>
                        <th className="py-3 px-6 text-left text-gray-600">Date de fin</th>
                        <th className="py-3 px-6 text-left text-gray-600">Actions</th>
                    </tr>
                    </thead>
                    <tbody>
                    {events.$values.map((event) => (
                        <tr key={event.id} className="border-b hover:bg-gray-50">
                            <td className="py-3 px-6 text-gray-700">{event.name}</td>
                            <td className="py-3 px-6 text-gray-500">{event.description}</td>
                            <td className="py-3 px-6 text-gray-500">{new Date(event.startDate).toLocaleDateString()}</td>
                            <td className="py-3 px-6 text-gray-500">{new Date(event.endDate).toLocaleDateString()}</td>
                            <td className="py-3 px-6 text-center">
                                <button
                                    onClick={() => handleDelete(event.id)}
                                    className="bg-red-600 hover:bg-red-700 text-white px-4 py-2 rounded-lg"
                                >
                                    Supprimer
                                </button>
                            </td>
                        </tr>
                    ))}
                    </tbody>
                </table>
            ) : (
                <p className="text-gray-500 text-center">Aucun événement trouvé.</p>
            )}
        </div>
    );
};

export default EventList;
