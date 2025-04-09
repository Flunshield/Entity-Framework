import React, { ReactNode } from "react";
import Header from "./Header";

interface LayoutProps {
    children: ReactNode;
}

const Layout: React.FC<LayoutProps> = ({ children }) => {
    return (
        <div className="flex flex-col min-h-screen bg-gray-50">
            <Header />
            <main className="flex-grow container mx-auto px-4 py-8">
                {children}
            </main>
            <footer className="bg-gray-800 text-gray-300 text-center py-4">
                © {new Date().getFullYear()} Plateforme de Gestion d'Événements. Tous droits réservés.
            </footer>
        </div>
    );
};

export default Layout;
