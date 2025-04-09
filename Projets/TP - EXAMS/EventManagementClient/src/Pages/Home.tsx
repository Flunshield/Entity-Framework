import React from "react";

const Home: React.FC = () => {
    return (
        <section className="bg-white p-8 rounded-2xl shadow-lg max-w-4xl mx-auto">
            <h1 className="text-3xl font-bold mb-4 text-gray-800">Gestion d'Événements - API REST</h1>
            <p className="text-gray-600 mb-4">
                Ce projet consiste à développer une API REST complète pour la gestion d'événements professionnels tels que des conférences, des salons ou encore des workshops.
                L'objectif est de permettre une gestion centralisée et efficace des événements, des participants, des sessions, des intervenants et des lieux.
            </p>
            <h2 className="text-2xl font-semibold mb-2 text-gray-700">Objectifs pédagogiques</h2>
            <ul className="list-disc list-inside text-gray-600 mb-4">
                <li>Modélisation des données avec Entity Framework Core</li>
                <li>Implémentation des opérations CRUD et des relations entre entités</li>
                <li>Optimisation des performances et des requêtes</li>
                <li>Respect des bonnes pratiques de conception d'API REST</li>
            </ul>
            <h2 className="text-2xl font-semibold mb-2 text-gray-700">Fonctionnalités clés</h2>
            <ul className="list-disc list-inside text-gray-600 mb-4">
                <li>Gestion complète des événements et des participants</li>
                <li>Association d'intervenants aux sessions</li>
                <li>Gestion des lieux et des salles</li>
                <li>Notation des sessions et génération de rapports statistiques</li>
                <li>Gestion des transactions financières et système de recommandations</li>
            </ul>
            <h2 className="text-2xl font-semibold mb-2 text-gray-700">Architecture technique</h2>
            <p className="text-gray-600 mb-4">
                L'API est développée avec ASP.NET Core 8 et utilise Entity Framework Core 8 pour la gestion des données. Le projet adopte une architecture en couches (Controllers, Services, Repositories, Entities) respectant les principes SOLID pour assurer maintenabilité et évolutivité.
            </p>
            <h2 className="text-2xl font-semibold mb-2 text-gray-700">Livrable attendu</h2>
            <p className="text-gray-600">
                Un projet complet comprenant le code source, les migrations de base de données, une documentation détaillée et des exemples d'appels API pour faciliter la prise en main et la compréhension du système.
            </p>
        </section>
    );
};

export default Home;
