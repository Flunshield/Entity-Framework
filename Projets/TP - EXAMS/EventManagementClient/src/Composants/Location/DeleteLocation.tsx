import React from "react";

interface DeleteLocationProps {
    locationId: number;
    onDeleted?: () => void;
}

const DeleteLocation: React.FC<DeleteLocationProps> = ({ locationId, onDeleted }) => {
    const handleDelete = async () => {
        if (confirm("Êtes-vous sûr de vouloir supprimer cet emplacement ?")) {
            try {
                const response = await fetch(`/api/Location/${locationId}`, {
                    method: "DELETE",
                });
                if (!response.ok) throw new Error("Erreur lors de la suppression de l'emplacement");
                alert("Emplacement supprimé avec succès !");
                if (onDeleted) onDeleted();
            } catch (error) {
                console.error(error);
            }
        }
    };

    return (
        <button onClick={handleDelete} className="bg-red-600 text-white px-4 py-2 rounded">
            Supprimer l'Emplacement
        </button>
    );
};

export default DeleteLocation;
