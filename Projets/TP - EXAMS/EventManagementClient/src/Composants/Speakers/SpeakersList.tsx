import React, { useState, useEffect } from 'react';

interface SpeakerDto {
    id: number;
    name: string;
    title: string;
    bio: string;
}

const SpeakersList: React.FC = () => {
    const [speakers, setSpeakers] = useState<SpeakerDto[]>([]);
    const [error, setError] = useState<string>('');

    useEffect(() => {
        const fetchSpeakers = async () => {
            try {
                const response = await fetch('/api/Speaker');
                if (!response.ok) {
                    throw new Error('Failed to fetch speakers');
                }
                const data = await response.json();
                setSpeakers(data);
            } catch (err) {
                setError('Unable to fetch speakers');
            }
        };

        fetchSpeakers();
    }, []);

    return (
        <div className="p-6">
            <h2 className="text-2xl font-semibold mb-4">Intervenants</h2>
            {error && <div className="text-red-500">{error}</div>}
            <ul>
                {speakers.map(speaker => (
                    <li key={speaker.id} className="mb-4">
                        <h3 className="font-bold">{speaker.name}</h3>
                        <p>{speaker.title}</p>
                        <p>{speaker.bio}</p>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default SpeakersList;
