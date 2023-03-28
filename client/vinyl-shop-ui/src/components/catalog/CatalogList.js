import { Box, Grid } from '@mui/material'
import { useDispatch, useSelector } from 'react-redux' 
import { getProducts } from "../../app/actions/catalog";
import { useEffect } from "react";
import CatalogListItem from './CatalogListItem';

function CatalogList() {
  const products = useSelector(state => state.catalog.products) 
  const selectedGenres = useSelector(state => state.genre.selectedGenres)
  const dispatch = useDispatch()

  useEffect(() => {
    dispatch(getProducts())
  }, [])
  
  return(
    <Box sx={{
      flexDirection: 'row',
      flexWrap: 'wrap',
      display: 'flex',
      justifyContent: 'center'
    }}>
      {products.map((product) => <CatalogListItem key={product.key} props={product}/>)}
    </Box>
  );
}

export default CatalogList