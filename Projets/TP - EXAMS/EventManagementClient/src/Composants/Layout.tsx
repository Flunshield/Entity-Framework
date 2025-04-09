import React, { ReactNode } from "react";
import Header from "./Header";

interface LayoutProps {
    children: ReactNode;
}

const Layout: React.FC<LayoutProps> = ({ children }) => {
    return (
        <div className="flex flex-col min-h-screen bg-gray-50 relative">
            <Header />
            <main className="flex-grow container mx-auto px-4 py-8 mb-16">
                {children}
            </main>
            <footer className="absolute right-1 bottom-0 w-5/6 bg-gradient-to-r from-green-300 to-blue-400 text-white text-center py-4">
                © {new Date().getFullYear()} Plateforme de Gestion d'Événements. Tous droits réservés.
            </footer>
        </div>
    );
};

export default Layout;
