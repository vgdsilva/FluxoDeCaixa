import React from 'react'; 
import { View, Text, StyleSheet } from 'react-native';
import { BaseScreen } from '../components/baseScreen';
import { Link } from 'expo-router';

export default class OnboardingScreen extends BaseScreen {

    render(): React.ReactNode 
    {
      return (
        <View style={styles.container}>
            <Link href="/home">to home page</Link>
        </View>
      );
    }

}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#121214',
    alignContent: 'center',
    alignItems: 'center'
  }
});