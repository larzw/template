import {
    usePersonsGetAll,
    usePersonsGetBy,
    personsDeleteBy,
    personsCreateBy,
    personsUpdateBy,
    PersonsEntity,
} from '../services/personsDal';
import Loading from './ui/Loading';
import ButtonPrimary from './ui/ButtonPrimary';
import H1 from './ui/H1';

export default function PersonsComponent() {
    const { dataPersonsGetBy, isLoadingPersonsGetBy } = usePersonsGetBy(4);
    const { dataPersonsGetAll, isLoadingPersonsGetAll } = usePersonsGetAll();

    if (isLoadingPersonsGetBy) {
        return Loading();
    }

    if (isLoadingPersonsGetAll) {
        return Loading();
    }

    return (
        <>
            <H1>Persons Page</H1>
            <div>
                name = {dataPersonsGetBy?.name} and id = {dataPersonsGetBy?.id}
            </div>
            <div>
                names and Ids:
                <div>
                    {dataPersonsGetAll?.map((x, index) => {
                        return (
                            <div key={index}>
                                {x.id},{x.name}
                            </div>
                        );
                    })}
                </div>
            </div>
            <div>
                <ButtonPrimary
                    onClick={async () => {
                        const x = await personsDeleteBy(5);
                        console.log(`deleted: ${x}`);
                    }}
                >
                    delete
                </ButtonPrimary>
            </div>
            <div>
                <ButtonPrimary
                    onClick={async () => {
                        const e: PersonsEntity = {
                            name: 'Pat',
                        };
                        const x = await personsCreateBy(e);
                        console.log(`created: ${x}`);
                    }}
                >
                    create
                </ButtonPrimary>
            </div>
            <div>
                <ButtonPrimary
                    onClick={async () => {
                        const e: PersonsEntity = {
                            id: 2,
                            name: 'John',
                        };
                        const x = await personsUpdateBy(e);
                        console.log(`updated: ${x}`);
                    }}
                >
                    update
                </ButtonPrimary>
            </div>
        </>
    );
}
