import { Box, ButtonBase, Typography } from "@mui/material"
import colors from '../../themes/colors'
import { useDispatch } from "react-redux";
import AddIcon from '@mui/icons-material/Add';
import RemoveIcon from '@mui/icons-material/Remove';
import DeleteIcon from '@mui/icons-material/Delete';
import { deleteCart } from "../../app/actions/cart/deleteCart";
import { updateCart } from '../../app/actions/cart/updateCart'

function OrderDialogListItem(props) {
  const item = props.item
  const dispatch = useDispatch()
  
  const onDeleteItem = () => {
    dispatch(deleteCart(item.id))
  }

  const onChangeItem = (sign) => {
    const queryAmount = item.amount + sign
    if (queryAmount > 0) {
      dispatch(updateCart({
        id: item.id,
        amount: queryAmount
      }))}
  }

  return(
    <Box sx={{
      flexDirection: 'row',
      display: 'flex',
      width: '96%',
      height: 170,
      backgroundColor: colors.dark,
      borderRadius: 2,
      mt: "2%"
    }}>
      <Box component="img"
          sx={{
          borderRadius: 2,
          height: 170,
          width: 170,
        }}
        alt="Изображение"
        src={item.image}/>

      <Box sx={{
        display: 'flex',
        width: "100%",        
        height: 170,
        flexDirection: 'column'
      }}>
        <Typography sx={{
          fontSize: 20,
          height: 55,
          p: 2,
          color: colors.white,
          overflow: 'hidden',
          fontWeight: 'bold',
          textAlign: 'center',
        }}>
          {item.name}
        </Typography>

        <Box sx={{
          width: '94%',
          height: 115,
          display: 'flex',
          flexDirection: 'row',
          alignItems: "center",
          justifyContent: 'flex-end'
        }}>
          <Typography sx={{
            color: colors.white,
            fontWeight: 'bold',
            fontSize: 20,
            textAlign: 'center',
          }}>
            {`${item.amount} шт.: ${item.price * item.amount} руб.`}
          </Typography>
          
        </Box>
      </Box>    
    </Box>)
}

export default OrderDialogListItem