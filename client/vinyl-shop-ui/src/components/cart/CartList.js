import { Box } from '@mui/material'
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { getCart } from '../../app/actions/cart/getCart'
import CartItem from './CartItem';

function CartList() {
  const cartItems = useSelector(state => state.cart.cartItems) 
  const dispatch = useDispatch()

  useEffect(() => {
    dispatch(getCart())
  }, [])

  return(
    <Box sx={{
      flexDirection: 'row',
      flexWrap: 'wrap',
      display: 'flex',
      justifyContent: 'center'
    }}>
      {cartItems.map((item) => <CartItem key={item.id} item={{...item}} />)}
    </Box>
  );
}

export default CartList