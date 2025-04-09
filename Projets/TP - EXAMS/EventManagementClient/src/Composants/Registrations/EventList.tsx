import React, { useState, useEffect } from 'react';

interface Event {
    id: number;
    name: string;
    date: string;
    description: string;
}

interface EventListProps {
    participantId: number;
}

const EventList: React.FC<EventListProps> = ({ participantId }) => {
    const [events, setEvents] = useState<Event[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string>('');

    useEffect(() => {
        const fetchEvents = async () => {
            try {
                const response = await fetch(`/api/registrations/participants/${participantId}/events`);
                if (!response.ok) {
                    throw new Error('Failed to fetch events');
                }
                const data = await response.json();
                setEvents(data);
            } catch (err) {
                setError('Unable to fetch events');
            } finally {
                setLoading(false);
            }
        };

        fetchEvents();
    }, [participantId]);

    if (loading) {
        return <div className="text-center">Loading events...</div>;
    }

    if (error) {
        return <div className="text-center text-red-500">{error}</div>;
    }

    return (
        <div className="p-4">
            <h2 className="text-2xl font-semibold mb-4">Events</h2>
            {events.length === 0 ? (
                <div className="text-center text-gray-500">No events found.</div>
            ) : (
                <ul className="space-y-4">
                    {events.map((event) => (
                        <li key={event.id} className="p-4 border border-gray-300 rounded-lg shadow-md">
                            <h3 className="text-xl font-bold">{event.name}</h3>
                            <p className="text-sm text-gray-500">{event.date}</p>
                            <p className="mt-2 text-gray-700">{event.description}</p>
                        </li>
                    ))}
                </ul>
            )}
        </div>
    );
};

export default EventList;
