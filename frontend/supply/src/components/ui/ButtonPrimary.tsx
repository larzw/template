import Button from '@mui/material/Button';

type Props = {
    children: string;
    onClick: () => void;
};

export default function ButtonPrimary({ children, onClick }: Props) {
    return (
        <Button variant="contained" onClick={onClick}>
            {children}
        </Button>
    );
}
