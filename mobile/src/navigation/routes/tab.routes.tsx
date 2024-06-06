import { createBottomTabNavigator } from '@react-navigation/bottom-tabs'
import { FontAwesomeIcon } from '@fortawesome/react-native-fontawesome'
import { faGear, faHouse, faWallet } from '@fortawesome/free-solid-svg-icons';
import MenuPrincipalScreen from '../../screens/MenuPrincipal';



const Tab = createBottomTabNavigator();

export default function TabRoutes() {
    return (
        <Tab.Navigator screenOptions={{ 
            headerShown: false
        }}>
            <Tab.Screen 
                name='home'
                component={MenuPrincipalScreen}
                options={{ 
                    tabBarShowLabel: false,
                    tabBarIcon: ({ color, size }) => <FontAwesomeIcon icon={faHouse} color={color} size={size} />
                }} />
            <Tab.Screen 
                name='wallet'
                component={MenuPrincipalScreen}
                options={{ 
                    tabBarShowLabel: false,
                    tabBarIcon: ({ color, size }) => <FontAwesomeIcon icon={faWallet} color={color} size={size} />
                }} />
            <Tab.Screen 
                name='setting'
                component={MenuPrincipalScreen}
                options={{ 
                    tabBarShowLabel: false,
                    tabBarIcon: ({ color, size }) => <FontAwesomeIcon icon={faGear} color={color} size={size} />
                }} />
        </Tab.Navigator>
    )
}