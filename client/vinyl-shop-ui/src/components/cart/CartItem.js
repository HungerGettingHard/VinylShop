import { Box, ButtonBase, Typography } from "@mui/material"
import colors from '../../themes/colors'
import { useDispatch } from "react-redux";
import AddIcon from '@mui/icons-material/Add';
import RemoveIcon from '@mui/icons-material/Remove';
import DeleteIcon from '@mui/icons-material/Delete';
import { deleteCart } from "../../app/actions/cart/deleteCart";

function CartItem(props) {
  const item = props.item
  const dispatch = useDispatch()
  
  const onDeleteItem = () => {
    dispatch(deleteCart(item.id))
  }

  return(
    <Box sx={{
      flexDirection: 'row',
      display: 'flex',
      width: 500,
      height: 250,
      backgroundColor: colors.dark,
      borderRadius: 2,
      m: 1
    }}>
      <Box component="img"
          sx={{
          borderRadius: 2,
          height: 250,
          width: 250,
        }}
        alt="Изображение"
        src={item.image}/>


      <Box sx={{
        display: 'flex',
        width: 250,
        height: 250,
        flexDirection: 'column'
      }}>
        <Typography sx={{
          fontSize: 20,
          height: 60,
          p: 2,
          color: colors.white,
          overflow: 'hidden',
          fontWeight: 'bold',
          textAlign: 'center',
        }}>
          {item.name}
        </Typography>

        <Box sx={{
          width: '100%',
          height: 100,
          display: 'flex',
          flexDirection: 'row',
          alignItems: "center",
          justifyContent: 'center'
        }}>
          <ButtonBase sx={{
            width: 40, 
            height: 40,
            borderRadius: 2
          }}>
            <RemoveIcon sx={{ color: colors.white }}/>
          </ButtonBase>
          <Typography sx={{
            color: colors.white,
            fontWeight: 'bold',
            fontSize: 20, 
            width: 40,
            textAlign: 'center',
          }}>
            {item.amount}
          </Typography>
          <ButtonBase sx={{
            width: 40, 
            height: 40,
            borderRadius: 2
          }}>
            <AddIcon sx={{ color: colors.white }}/>
          </ButtonBase>
          <ButtonBase sx={{
            width: 40, 
            height: 40,
            backgroundColor: colors.red,
            borderRadius: 2,
            ml: 2
          }} onClick={onDeleteItem}>
            <DeleteIcon sx={{ color: colors.white }}/>
          </ButtonBase>
        </Box>
      </Box>    
    </Box>)
}

export default CartItem