import React, { useEffect, useState } from "react";

interface ParticipantDto {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    company: string;
    jobTitle: string;
}

interface ParticipantDetailProps {
    participantId: number;
}

const ParticipantDetail: React.FC<ParticipantDetailProps> = ({ participantId }) => {
    const [participant, setParticipant] = useState<ParticipantDto | null>(null);

    useEffect(() => {
        fetch(`/api/Participant/${participantId}`)
            .then(res => res.json())
            .then(setParticipant)
            .catch(console.error);
    }, [participantId]);

    if (!participant) return <p className="text-gray-600">Chargement du participant...</p>;

    return (
        <div className="bg-white p-6 rounded-xl shadow-md">
            <h2 className="text-2xl font-bold text-gray-800">{participant.firstName} {participant.lastName}</h2>
            <p className="text-gray-600">{participant.jobTitle} chez {participant.company}</p>
            <p className="text-sm text-gray-500">{participant.email}</p>
        </div>
    );
};

export default ParticipantDetail;
