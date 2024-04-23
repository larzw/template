import { http, HttpResponse } from 'msw';

export const handlers = [
    http.get('http://localhost:5284/api/v1/Persons/GetBy/4', () => {
        return HttpResponse.json({
            id: 4,
            name: 'Tim',
        });
    }),
    http.get('http://localhost:5284/api/v1/Persons/GetAll', () => {
        return HttpResponse.json([
            {
                id: 4,
                name: 'Tim',
            },
            {
                id: 5,
                name: 'Mike',
            },
        ]);
    }),
    http.delete('http://localhost:5284/api/v1/Persons/DeleteBy/5', () => {
        return HttpResponse.json(1);
    }),
    http.post('http://localhost:5284/api/v1/Persons/CreateBy', () => {
        return HttpResponse.json({
            id: 6,
            name: 'Pat',
        });
    }),
    http.put('http://localhost:5284/api/v1/Persons/UpdateBy', () => {
        return HttpResponse.json({
            id: 2,
            name: 'John',
        });
    }),
];
