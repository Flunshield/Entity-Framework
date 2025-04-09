import React from "react";
import Slider from "react-slick";

import img1 from "/architecture_configurations.png";
import img2 from "/architecture_controllers.png";
import img3 from "/architecture_datas.png";
import img4 from "/architecture_Dtos.png";
import img5 from "/architecture_interfaces.png";
import img6 from "/architecture_migrations.png";
import img7 from "/architecture_models.png";
import img8 from "/architecture_repository.png";
import img9 from "/architecture_service.png";

import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";

const Architecture: React.FC = () => {
    const settings = {
        dots: true,
        infinite: true,
        speed: 500,
        slidesToShow: 2,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 1000,
        centerMode: true,
        focusOnSelect: true,
    };

    const pathImg = [
        img1, img2, img3, img4, img5, img6, img7, img8, img9
    ];

    return (<section className="max-w-4xl mx-auto bg-white p-8 rounded-2xl shadow-lg">
        <h1 className="text-3xl font-bold text-gray-800 mb-4">Architecture Technique</h1>
        <p className="text-gray-600 mb-4">
            Le projet repose sur une architecture en couches respectant les principes SOLID pour garantir la
            maintenabilité et l’évolutivité du système.
        </p>
        <ul className="list-disc list-inside text-gray-600 space-y-2 mb-4">
            <li><strong>Framework :</strong> ASP.NET Core 8.0.14</li>
            <li><strong>ORM :</strong> Entity Framework Core 8.0.0</li>
            <li><strong>SGBD :</strong> MariaDb - <a href="http://localhost:8080" target="_blank"
                                                     className="text-blue-500 underline">URL PhpMyadmin</a></li>
            <li><strong>Architecture :</strong> Clean Architecture / Architecture en couches (Controllers, Services,
                Repositories, Models, Services).
            </li>
            <li><strong>Principes :</strong> Respect des standards RESTful, validation des données, gestion des
                exceptions, documentation via Swagger. - <a href="http://localhost:5162/swagger/index.html"
                                                            target="_blank" className="text-blue-500 underline">URL
                    Swagger</a></li>
        </ul>

        <div className="p-8 rounded-xl shadow-md bg-gray-300 mb-4">
            <h3 className="text-xl font-semibold text-gray-800 mb-2">Images de l'architecture</h3>
            <Slider {...settings}>
                {pathImg.map((path, index) => (
                    <div key={index}>
                        <img
                            src={path}
                            alt={`Architecture ${index + 1}`}
                            className="max-w-[250px] h-auto rounded-lg"
                        />
                    </div>
                ))}
            </Slider>
        </div>

        <p className="text-gray-600">
            L'utilisation des migrations EF Core et de la Fluent API permet une gestion robuste du schéma de base de
            données.
            Le projet inclut également des tests unitaires pour les services critiques afin d’assurer la qualité du
            code.
        </p>
    </section>);
};

export default Architecture;
