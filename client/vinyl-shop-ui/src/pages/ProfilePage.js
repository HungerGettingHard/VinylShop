import { Box } from "@mui/material";
import { useEffect } from "react";
import { useDispatch } from "react-redux";
import { setProfile } from '../features/sideMenuSlice'

function ProfilePage() {
  const dispatch = useDispatch()

  useEffect(() => {
    dispatch(setProfile())
  }, [])

  return(
    <Box sx={{
      display: 'flex',
      alignItems: 'center',
      pt: '120px',
      justifyContent: 'center',
      flexDirection: 'row'
    }}>
    </Box>
  );
}

export default ProfilePage