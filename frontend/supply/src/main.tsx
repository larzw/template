import React from 'react';
import ReactDOM from 'react-dom/client';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import HomePage from './pages/HomePage';
import PersonsPage from './pages/PersonsPage';
import DevPage from './pages/DevPage';

async function enableMocking() {
    if (!import.meta.env.DEV) {
        return;
    }

    const { worker } = await import('./mocks/browser');

    return worker.start();
}

const queryClient = new QueryClient({});

const router = createBrowserRouter([
    {
        path: '/',
        element: <HomePage />,
    },
    {
        path: 'HomePage',
        element: <HomePage />,
    },
    {
        path: 'PersonsPage',
        element: <PersonsPage />,
    },
    {
        path: 'DevPage',
        element: <DevPage />,
    },
]);

enableMocking().then(() => {
    ReactDOM.createRoot(document.getElementById('root')!).render(
        <React.StrictMode>
            <QueryClientProvider client={queryClient}>
                <RouterProvider router={router} />
            </QueryClientProvider>
        </React.StrictMode>
    );
});
