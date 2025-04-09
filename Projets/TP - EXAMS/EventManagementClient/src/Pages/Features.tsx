import React from "react";
import EventList from "../Composants/Events/EventList.tsx";
import CreateEvent from "../Composants/Events/CreateEvent.tsx";
import UpdateEvent from "../Composants/Events/UpdateEvent.tsx";

const Features: React.FC = () => {
    return (
        <>
            <section className="max-w-4xl mx-auto bg-white p-8 rounded-2xl shadow-lg mb-8">
                <h1 className="text-3xl font-bold text-gray-800 mb-4">Fonctionnalités Clés</h1>
                <ul className="list-disc list-inside text-gray-600 space-y-2">
                    <li>CRUD complet pour les événements, participants, sessions, intervenants et lieux.</li>
                    <li>Filtrage des événements par date, lieu, catégorie et statut.</li>
                    <li>Pagination des résultats pour les listes d'événements et de participants.</li>
                    <li>Gestion des inscriptions et désinscriptions des participants aux événements.</li>
                    <li>Consultation du programme et association d'intervenants aux sessions.</li>
                    <li>Système de notation des sessions avec génération de rapports statistiques.</li>
                    <li>Gestion des transactions financières et recommandations personnalisées.</li>
                    <li>Gestion des salles au sein des lieux et attribution des sessions aux salles.</li>
                </ul>
            </section>

            <section className="max-w-4xl mx-auto p-8 bg-white rounded-2xl shadow-lg">
                <h2 className="text-2xl font-bold text-gray-800 mb-4">Gestion des Événements (CRUD)</h2>

                {/* Tableau des événements */}
                <EventList />

                {/* Formulaires de gestion des événements */}
                <div className="grid grid-cols-1 md:grid-cols-2 gap-6 mt-8">
                        <CreateEvent />
                        <UpdateEvent />
                </div>
            </section>
        </>
    );
};

export default Features;
