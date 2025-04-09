import React, { useEffect, useState } from "react";

interface EventDto {
    id: number;
    title: string;
    description: string;
    startDate: string;
    endDate: string;
    status: string;
}

interface EventDetailProps {
    eventId: number;
}

const EventDetail: React.FC<EventDetailProps> = ({ eventId }) => {
    const [event, setEvent] = useState<EventDto | null>(null);

    useEffect(() => {
        fetch(`/api/Event/${eventId}`)
            .then(res => res.json())
            .then(data => setEvent(data))
            .catch(console.error);
    }, [eventId]);

    if (!event) return <p className="text-gray-600">Chargement de l'événement...</p>;

    return (
        <div className="bg-white p-6 rounded-xl shadow-md">
            <h2 className="text-2xl font-bold text-gray-800">{event.title}</h2>
            <p className="text-gray-600">{event.description}</p>
            <p className="text-sm text-gray-500">
                Du {new Date(event.startDate).toLocaleDateString()} au {new Date(event.endDate).toLocaleDateString()}
            </p>
            <p className="text-sm text-gray-500">Statut : {event.status}</p>
        </div>
    );
};

export default EventDetail;
