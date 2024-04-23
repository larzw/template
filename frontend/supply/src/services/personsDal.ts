import { useQuery } from '@tanstack/react-query';
import api from './api';

export type PersonsEntity = {
    id?: number;
    name?: string;
};

export function usePersonsGetAll() {
    const { data: dataPersonsGetAll, isLoading: isLoadingPersonsGetAll } =
        useQuery({
            queryFn: async () => {
                const { data } =
                    await api.get<PersonsEntity[]>('Persons/GetAll');
                return data;
            },
            queryKey: ['personsGetAll'],
        });

    return { dataPersonsGetAll, isLoadingPersonsGetAll };
}

export function usePersonsGetBy(id: number) {
    const { data: dataPersonsGetBy, isLoading: isLoadingPersonsGetBy } =
        useQuery({
            queryFn: async () => {
                const { data } = await api.get<PersonsEntity>(
                    `Persons/GetBy/${id}`
                );
                return data;
            },
            queryKey: ['personsGetBy', id],
        });
    return { dataPersonsGetBy, isLoadingPersonsGetBy };
}

export async function personsDeleteBy(id: number) {
    const { data: numberPersonsDeleteBy } = await api.delete<number>(
        `Persons/DeleteBy/${id}`
    );
    return numberPersonsDeleteBy;
}

export async function personsCreateBy(personsEntity: PersonsEntity) {
    const { data: entityPersonsCreateBy } = await api.post<PersonsEntity>(
        'Persons/CreateBy',
        personsEntity
    );
    return entityPersonsCreateBy;
}

export async function personsUpdateBy(personsEntity: PersonsEntity) {
    const { data: numberPersonsUpdateBy } = await api.put<PersonsEntity>(
        'Persons/UpdateBy',
        personsEntity
    );
    return numberPersonsUpdateBy;
}
