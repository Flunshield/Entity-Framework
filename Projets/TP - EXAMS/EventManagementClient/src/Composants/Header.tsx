import React from "react";
import { Link } from "react-router-dom";

const Header: React.FC = () => {
    return (
        <header className="bg-gradient-to-r from-blue-400 to-green-300 text-white p-6 fixed left-1 top-0 h-full w-1/6 flex flex-col justify-between">
            <div className="container mx-auto flex flex-col items-start p-4">
                <h1 className="text-2xl font-bold mb-6">Plateforme de Gestion d'Événements</h1>
                <nav>
                    <ul className="flex flex-col space-y-6">
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
