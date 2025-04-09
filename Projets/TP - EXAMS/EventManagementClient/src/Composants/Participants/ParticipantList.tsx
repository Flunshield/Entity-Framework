import React, { useEffect, useState } from "react";

interface ParticipantDto {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    company: string;
    jobTitle: string;
}

const ParticipantList: React.FC = () => {
    const [participants, setParticipants] = useState<ParticipantDto[]>([]);

    useEffect(() => {
        fetch("/api/Participant")
            .then(res => res.json())
            .then(setParticipants)
            .catch(console.error);
    }, []);

    return (
        <div className="bg-white p-6 rounded-xl shadow-md">
            <h2 className="text-2xl font-bold mb-4 text-gray-800">Liste des Participants</h2>
            <ul className="space-y-4">
                {participants.map(p => (
                    <li key={p.id} className="border p-4 rounded-lg">
                        <p className="text-lg font-semibold">{p.firstName} {p.lastName}</p>
                        <p className="text-gray-600">{p.jobTitle} chez {p.company}</p>
                        <p className="text-sm text-gray-500">{p.email}</p>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default ParticipantList;
