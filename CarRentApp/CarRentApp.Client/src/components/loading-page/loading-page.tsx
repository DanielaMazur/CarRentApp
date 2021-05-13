import { Box, CircularProgress } from "@material-ui/core";

const LoadingPage = () => {
  return (
    <Box
      display="flex"
      justifyContent="center"
      alignItems="center"
      height="80vh"
    >
      <CircularProgress size={50} />
    </Box>
  );
};

export { LoadingPage };
