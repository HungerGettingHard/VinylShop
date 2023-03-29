import { Box } from '@mui/material'
import { useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { getCart } from '../../app/actions/cart/getCart'

function CartList() {
  // const cartItems = useSelector(state => state.catalog.products) 
  const dispatch = useDispatch()

  useEffect(() => {
    dispatch(getCart())
  })

  return(
    <Box sx={{
      flexDirection: 'row',
      flexWrap: 'wrap',
      display: 'flex',
      justifyContent: 'center'
    }}>
      {/* products.map((product) => <CatalogListItem key={product.key} product={{...product}} />) */}
    </Box>
  );
}

export default CartList