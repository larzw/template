import { useQuery } from '@tanstack/react-query';
import axios from 'axios';

export type PersonsEntity = {
    id?: number;
    name?: string;
};

export function personsGetBy(id: number) {
    const { data: dataPersonsGetBy, isLoading: isLoadingPersonsGetBy } =
        useQuery({
            queryFn: async () => {
                const { data } = await axios.get<PersonsEntity>(
                    `http://localhost:5284/api/v1/Persons/GetBy/${id}`
                );
                return data;
            },
            queryKey: ['personsGetBy', id],
        });
    return { dataPersonsGetBy, isLoadingPersonsGetBy };
}

export function Comp1() {
    const { dataPersonsGetBy, isLoadingPersonsGetBy } = personsGetBy(4);

    const x = 1;
    const y = 2;
    const z = 3;

    if (isLoadingPersonsGetBy) {
        return <div>loading</div>;
    }

    return (
        <>
            <div>comp 2 </div>
            <div>name is: {dataPersonsGetBy?.name}</div>
        </>
    );
}

export default function DevPage() {
    const x = 1;
    const y = 2;
    const z = 3;

    return (
        <>
            <div>dev page </div>
            <Comp1 />
        </>
    );
}
