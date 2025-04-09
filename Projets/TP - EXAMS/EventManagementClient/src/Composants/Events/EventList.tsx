import React, { useEffect, useState } from "react";
import {getAllEvent} from "../../Others/utils.ts";

interface EventDto {
    $id: string;
    $values: {
        $id: string;
        id: number;
        name: string;
        description: string;
        startDate: string;
        endDate: string;
        locationId: number;
        categoryId: number;
        registrationDate: string | null;
        attendanceStatus: string | null;
    }[];
}


const EventList: React.FC = () => {
    const [events, setEvents] = useState<EventDto | null>(null);

    useEffect(() => {
        getAllEvent()
            .then(data => setEvents(data))
            .catch(error => console.error("Error fetching events:", error));
    }, []);

    return (
        <div className="bg-white p-6 rounded-xl shadow-md">
            <h2 className="text-2xl font-bold mb-4 text-gray-800">Liste des Événements</h2>
            <p>Methode GET : /Event</p>
            <ul className="space-y-4">
                {events?.$values.map(event => (
                    <li key={event.id} className="border p-4 rounded-lg">
                        <h3 className="text-xl font-semibold">{event.name}</h3>
                        <p className="text-gray-600">{event.description}</p>
                        <p className="text-sm text-gray-500">
                            Du {new Date(event.startDate).toLocaleDateString()} au {new Date(event.endDate).toLocaleDateString()}
                        </p>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default EventList;
