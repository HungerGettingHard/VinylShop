import { Box } from "@mui/material";
import { useEffect } from "react";
import { useDispatch } from "react-redux";
import CatalogBox from "../components/catalog/CatalogBox";
import GenreSelectorBox from "../components/genre/GenreSelectorBox";
import { setCatalog } from '../features/sideMenuSlice'

function CatalogPage() {
  const dispatch = useDispatch()

  useEffect(() => {
    dispatch(setCatalog())
  }, [])

  return(
    <Box sx={{
      display: 'flex',
      alignItems: 'center',
      pt: '120px',
      justifyContent: 'center',
      flexDirection: 'column'
    }}>
      <GenreSelectorBox/>
      <CatalogBox/>
    </Box>
  );
}

export default CatalogPage