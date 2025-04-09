import {URL_API} from "./Constantes.ts";

export function getAllEvent() {
    return fetch(`${URL_API}/Event`)
        .then(res => res.json())
        .catch(console.error);
}

export function fetchLocations() {
    return fetch(`${URL_API}/Location`)
        .then((res) => res.json())
        .catch(console.error);
}

export function fetchCategories() {
    return fetch(`${URL_API}/Event/categories`)
        .then((res) => res.json())
        .catch(console.error);
}
