import React, { useState, useEffect } from 'react';

interface SessionDto {
    name: string;
    startDate: string;
    endDate: string;
}

const UpdateSession: React.FC<{ id: number }> = ({ id }) => {
    const [name, setName] = useState<string>('');
    const [startDate, setStartDate] = useState<string>('');
    const [endDate, setEndDate] = useState<string>('');
    const [error, setError] = useState<string>('');
    const [success, setSuccess] = useState<string>('');
    const [loading, setLoading] = useState<boolean>(true);

    useEffect(() => {
        const fetchSession = async () => {
            try {
                const response = await fetch(`/api/Session/${id}`);
                if (!response.ok) {
                    throw new Error('Failed to fetch session');
                }
                const data = await response.json();
                setName(data.name);
                setStartDate(data.startDate);
                setEndDate(data.endDate);
            } catch (err) {
                setError('Unable to fetch session details' + err);
            } finally {
                setLoading(false);
            }
        };

        fetchSession();
    }, [id]);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        const updatedSession: SessionDto = {
            name,
            startDate,
            endDate,
        };

        try {
            const response = await fetch(`/api/Session/${id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(updatedSession),
            });

            if (!response.ok) {
                throw new Error('Failed to update session');
            }

            setSuccess('Session updated successfully');
            setError('');
        } catch (err) {
            setError('Failed to update session' + err);
        }
    };

    if (loading) {
        return <div>Loading session details...</div>;
    }

    return (
        <div className="p-6 max-w-md mx-auto bg-white rounded-lg shadow-md">
            <h2 className="text-2xl font-semibold mb-4 text-center">Update Session</h2>
            <form onSubmit={handleSubmit}>
                <div className="mb-4">
                    <label htmlFor="name" className="block text-sm font-medium text-gray-700">Session Name</label>
                    <input
                        type="text"
                        id="name"
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        required
                        className="mt-1 block w-full p-2 border border-gray-300 rounded-md"
                    />
                </div>

                <div className="mb-4">
                    <label htmlFor="startDate" className="block text-sm font-medium text-gray-700">Start Date</label>
                    <input
                        type="date"
                        id="startDate"
                        value={startDate}
                        onChange={(e) => setStartDate(e.target.value)}
                        required
                        className="mt-1 block w-full p-2 border border-gray-300 rounded-md"
                    />
                </div>

                <div className="mb-4">
                    <label htmlFor="endDate" className="block text-sm font-medium text-gray-700">End Date</label>
                    <input
                        type="date"
                        id="endDate"
                        value={endDate}
                        onChange={(e) => setEndDate(e.target.value)}
                        required
                        className="mt-1 block w-full p-2 border border-gray-300 rounded-md"
                    />
                </div>

                <button
                    type="submit"
                    className="w-full bg-blue-500 text-white py-2 px-4 rounded-md hover:bg-blue-600"
                >
                    Update Session
                </button>
            </form>

            {error && <div className="mt-4 text-red-500">{error}</div>}
            {success && <div className="mt-4 text-green-500">{success}</div>}
        </div>
    );
};

export default UpdateSession;
