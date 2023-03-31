import { Box } from '@mui/material'
import ProfileOrderList from './ProfileOrderList';

function ProfileBox() {
  return(
    <Box sx={{
      display: 'flex',
      width: '80%',
      flexDirection: 'column'
    }}>
      <ProfileOrderList/>
    </Box>
  );
}

export default ProfileBox