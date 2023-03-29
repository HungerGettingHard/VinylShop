import { Box } from "@mui/material"
import colors from '../../themes/colors'
import { useDispatch } from "react-redux";
import { open } from '../../features/catalog/catalogDialogSlice'

function CartItem(props) {
  // const product = { ...props.product }
  const dispatch = useDispatch()
  
  return(
    <Box sx={{
      flexDirection: 'column',
      display: 'flex',
      width: 250,
      height: 300,
      backgroundColor: colors.dark,
      borderRadius: 2,
      m: 1
    }}>
      {/* <Box component="img"
          sx={{
          borderRadius: 2,
          height: 250,
          width: 250,
        }}
        alt="Изображение"
        src={product.image}/> */}    
    </Box>)
}

export default CartItem