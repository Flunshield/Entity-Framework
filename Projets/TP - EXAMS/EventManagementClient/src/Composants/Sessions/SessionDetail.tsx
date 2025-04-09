import React, { useState, useEffect } from 'react';

interface Session {
    id: number;
    name: string;
    startDate: string;
    endDate: string;
}

const SessionDetail: React.FC<{ id: number }> = ({ id }) => {
    const [session, setSession] = useState<Session | null>(null);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string>('');

    useEffect(() => {
        const fetchSession = async () => {
            try {
                const response = await fetch(`/api/Session/${id}`);
                if (!response.ok) {
                    throw new Error('Failed to fetch session');
                }
                const data = await response.json();
                setSession(data);
            } catch (err) {
                setError('Unable to fetch session');
            } finally {
                setLoading(false);
            }
        };

        fetchSession();
    }, [id]);

    if (loading) {
        return <div>Loading session...</div>;
    }

    if (error) {
        return <div className="text-red-500">{error}</div>;
    }

    if (!session) {
        return <div>No session found.</div>;
    }

    return (
        <div className="p-4">
            <h2 className="text-2xl font-semibold mb-4">{session.name}</h2>
            <p>{session.startDate} - {session.endDate}</p>
        </div>
    );
};

export default SessionDetail;
