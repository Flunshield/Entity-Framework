import React from "react";

const Livrable: React.FC = () => {
    return (
        <section className="max-w-4xl mx-auto bg-white p-8 rounded-2xl shadow-lg">
            <h1 className="text-3xl font-bold text-gray-800 mb-4">Livrables Attendues</h1>
            <p className="text-gray-600 mb-4">
                Le projet final devra inclure l’ensemble des éléments nécessaires pour garantir son bon fonctionnement et sa maintenabilité.
            </p>
            <ul className="list-disc list-inside text-gray-600 space-y-2 mb-4">
                <li>Code source complet de l’API REST.</li>
                <li>Migrations EF Core pour la gestion du schéma de base de données.</li>
                <li>Documentation détaillée avec architecture du projet et instructions d’installation.</li>
                <li>Exemples d’appels API ou une collection Postman.</li>
                <li>Présentation des fonctionnalités implémentées et des défis rencontrés.</li>
            </ul>
            <p className="text-gray-600">
                L’évaluation portera sur la qualité du modèle de données, la performance des requêtes, le respect des bonnes pratiques REST, la gestion des erreurs et l’organisation générale du projet.
            </p>
        </section>
    );
};

export default Livrable;
