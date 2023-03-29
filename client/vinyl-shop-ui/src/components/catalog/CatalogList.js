import { Box } from '@mui/material'
import { useDispatch, useSelector } from 'react-redux' 
import { getProducts } from "../../app/actions/catalog";
import { useEffect, useState } from "react";
import CatalogListItem from './CatalogListItem';

function CatalogList() {
  const products = useSelector(state => state.catalog.products) 
  const selectedGenres = useSelector(state => state.genre.selectedGenres)
  const [isSetup, setIsSetup] = useState(true)
  const dispatch = useDispatch()

  useEffect(() => {
    if (!isSetup) {
      dispatch(getProducts(selectedGenres))
    } else {
      setIsSetup(false)
    }
  }, [selectedGenres])
  
  return(
    <Box sx={{
      flexDirection: 'row',
      flexWrap: 'wrap',
      display: 'flex',
      justifyContent: 'center'
    }}>
      {products.map((product) => <CatalogListItem key={product.key} product={{...product}} />)}
    </Box>
  );
}

export default CatalogList