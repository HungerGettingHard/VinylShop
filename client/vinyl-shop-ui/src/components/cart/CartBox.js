import { Box } from '@mui/material'
import CartList from './CartList';

function CartBox() {
  return(
    <Box sx={{
      display: 'flex',
      width: '80%',
      flexDirection: 'column'
    }}>
        <CartList/>
    </Box>
  );
}

export default CartBox