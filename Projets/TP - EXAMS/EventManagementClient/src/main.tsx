import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import {createBrowserRouter, RouterProvider} from "react-router";
import Home from "./Pages/Home.tsx";
import Layout from "./Composants/Layout.tsx";
import Features from "./Pages/Features.tsx";
import Architecture from "./Pages/Architecture.tsx";
import Livrables from "./Pages/Livrables.tsx";

const router = createBrowserRouter([
    {
        path: "/",
        element: <Layout><Home /></Layout>,
    },
    {
        path: "/features",
        element: <Layout><Features /></Layout>,
    },
    {
        path: "/architecture",
        element: <Layout><Architecture /></Layout>,
    },
    {
        path:"/livrables",
        element: <Layout><Livrables/></Layout>
    }
]);

createRoot(document.getElementById('root')!).render(
  <StrictMode>

      <RouterProvider router={router} />

  </StrictMode>,
)


