import React from "react";
import { Link } from "react-router-dom";

const Header: React.FC = () => {
    return (
        <header className="bg-gradient-to-r from-blue-600 to-indigo-700 text-white p-6 shadow-md">
            <div className="container mx-auto flex justify-between items-center">
                <h1 className="text-2xl font-bold">Plateforme de Gestion d'Événements</h1>
                <nav>
                    <ul className="flex space-x-6">
                        <li>
                            <Link to="/" className="hover:underline">
                                Acceuil
                            </Link>
                        </li>
                        <li>
                            <Link to="/features" className="hover:underline">
                                Fonctionnalités
                            </Link>
                        </li>
                        <li>
                            <Link to="/architecture" className="hover:underline">
                                Architecture
                            </Link>
                        </li>
                        <li>
                            <Link to="/livrables" className="hover:underline">
                                Livrable
                            </Link>
                        </li>
                    </ul>
                </nav>
            </div>
        </header>
    );
};

export default Header;
