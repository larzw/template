import Typography from '@mui/material/Typography';

type Props = {
    children: string;
};

export default function H1({ children }: Props) {
    return <Typography variant="h1">{children}</Typography>;
}
