import React from "react";

interface DeleteParticipantProps {
    participantId: number;
    onDeleted?: () => void;
}

const DeleteParticipant: React.FC<DeleteParticipantProps> = ({ participantId, onDeleted }) => {
    const handleDelete = async () => {
        if (confirm("Supprimer ce participant ?")) {
            try {
                const res = await fetch(`/api/Participant/${participantId}`, {
                    method: "DELETE",
                });
                if (!res.ok) throw new Error("Erreur lors de la suppression");
                alert("Participant supprimé !");
                if (onDeleted) onDeleted();
            } catch (err) {
                console.error(err);
            }
        }
    };

    return (
        <button onClick={handleDelete} className="bg-red-600 text-white px-4 py-2 rounded">
            Supprimer
        </button>
    );
};

export default DeleteParticipant;
