import React, { useState, useEffect } from 'react';

interface Session {
    id: number;
    name: string;
    startDate: string;
    endDate: string;
}

const SessionList: React.FC = () => {
    const [sessions, setSessions] = useState<Session[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string>('');

    useEffect(() => {
        const fetchSessions = async () => {
            try {
                const response = await fetch('/api/Session');
                if (!response.ok) {
                    throw new Error('Failed to fetch sessions');
                }
                const data = await response.json();
                setSessions(data);
            } catch (err) {
                setError('Unable to fetch sessions');
            } finally {
                setLoading(false);
            }
        };

        fetchSessions();
    }, []);

    if (loading) {
        return <div className="text-center">Loading sessions...</div>;
    }

    if (error) {
        return <div className="text-center text-red-500">{error}</div>;
    }

    return (
        <div className="p-4">
            <h2 className="text-2xl font-semibold mb-4">Sessions</h2>
            {sessions.length === 0 ? (
                <div className="text-center text-gray-500">No sessions found.</div>
            ) : (
                <ul className="space-y-4">
                    {sessions.map((session) => (
                        <li key={session.id} className="p-4 border border-gray-300 rounded-lg shadow-md">
                            <h3 className="text-xl font-bold">{session.name}</h3>
                            <p className="text-sm text-gray-500">{session.startDate} - {session.endDate}</p>
                        </li>
                    ))}
                </ul>
            )}
        </div>
    );
};

export default SessionList;
