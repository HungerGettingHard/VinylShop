import { Box, ButtonBase, Typography } from "@mui/material"
import { useDispatch, useSelector } from "react-redux"
import colors from "../../themes/colors"
import { selectDestination } from "../../features/order/orderDialogSlice"

function DestinationSelector() {
  const destinations = useSelector(store => store.orderDialog.destinations)
  const dispatch = useDispatch()

  return(
  <Box>
    {destinations.map((des) => 
      <ButtonBase sx={{
        width: 150,
        height: 65,
        backgroundColor: des.isSelected ? colors.purple : null,
        m: 1,
        display: 'flex',
        alignItems: "center",
        justifyContent: 'center',
        borderRadius: 2
      }} key={des.id}
      onClick={() => { dispatch(selectDestination(des.id))}}>
        <Typography sx={{
          color: des.isSelected ? colors.white : colors.gray,
          fontWeight: 'bold',
          fontSize: 18,
          textAlign: 'center'
        }}>
          {des.name}
        </Typography>
      </ButtonBase>)}
  </Box>)
}

export default DestinationSelector