import React, { useState } from 'react';

interface EventParticipantDto {
    participantId: number;
    eventId: number;
}

const RegisterParticipant: React.FC = () => {
    const [participantId, setParticipantId] = useState<number>(0);
    const [eventId, setEventId] = useState<number>(0);
    const [isRegistered, setIsRegistered] = useState<boolean>(false);
    const [error, setError] = useState<string>('');
    const [loading, setLoading] = useState<boolean>(false);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setLoading(true);
        setError('');

        const requestData: EventParticipantDto = {
            participantId,
            eventId,
        };

        try {
            const response = await fetch('/api/registrations', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(requestData),
            });

            if (!response.ok) {
                throw new Error('Failed to register participant');
            }

            setIsRegistered(true);
        } catch (err) {
            setError('Failed to register participant');
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="p-6 max-w-md mx-auto bg-white rounded-lg shadow-md">
            <h2 className="text-2xl font-semibold mb-4 text-center">Register for Event</h2>
            <form onSubmit={handleSubmit}>
                <div className="mb-4">
                    <label htmlFor="participantId" className="block text-sm font-medium text-gray-700">
                        Participant ID
                    </label>
                    <input
                        type="number"
                        id="participantId"
                        value={participantId}
                        onChange={(e) => setParticipantId(Number(e.target.value))}
                        required
                        className="mt-1 block w-full p-2 border border-gray-300 rounded-md"
                    />
                </div>

                <div className="mb-4">
                    <label htmlFor="eventId" className="block text-sm font-medium text-gray-700">
                        Event ID
                    </label>
                    <input
                        type="number"
                        id="eventId"
                        value={eventId}
                        onChange={(e) => setEventId(Number(e.target.value))}
                        required
                        className="mt-1 block w-full p-2 border border-gray-300 rounded-md"
                    />
                </div>

                <div className="flex items-center justify-between">
                    <button
                        type="submit"
                        disabled={loading}
                        className="w-full bg-blue-500 text-white font-semibold py-2 px-4 rounded-md hover:bg-blue-600 disabled:bg-gray-400"
                    >
                        {loading ? 'Registering...' : 'Register'}
                    </button>
                </div>
            </form>

            {isRegistered && (
                <div className="mt-4 text-green-500 text-center">Participant successfully registered!</div>
            )}

            {error && <div className="mt-4 text-red-500 text-center">{error}</div>}
        </div>
    );
};

export default RegisterParticipant;
