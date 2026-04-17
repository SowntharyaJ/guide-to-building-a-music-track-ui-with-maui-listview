# guide-to-building-a-music-track-ui-with-maui-listview

Explains about step by step guide to building a music track ui with .NET MAUI ListView.

## Sample

```xaml
<syncfusion:SfListView
        x:Name="listView"
        ItemSize="94"
        ItemsSource="{Binding AudioCollection}"
        ScrollBarVisibility="Always"
        SelectionMode="None">

        <syncfusion:SfListView.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="*" />
                        <RowDefinition Height="1" />
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="94" />
                        <ColumnDefinition Width="*" />
                        <ColumnDefinition Width="70" />
                    </Grid.ColumnDefinitions>
                    <Frame
                        Grid.Row="0"
                        Grid.Column="0"
                        Padding="0"
                        CornerRadius="4"
                        HasShadow="False"
                        HeightRequest="72"
                        HorizontalOptions="Center"
                        IsClippedToBounds="True"
                        WidthRequest="72">
                        <Image
                            Grid.Row="0"
                            Grid.Column="0"
                            Aspect="Fill"
                            HeightRequest="72"
                            HorizontalOptions="Center"
                            Source="{Binding Image}"
                            VerticalOptions="FillAndExpand"
                            WidthRequest="72" />
                    </Frame>
                    <Grid
                        Grid.Row="0"
                        Grid.Column="1"
                        VerticalOptions="CenterAndExpand">
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto" />
                            <RowDefinition Height="Auto" />
                            <RowDefinition Height="Auto" />
                        </Grid.RowDefinitions>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="*" />
                            <ColumnDefinition Width="60" />
                        </Grid.ColumnDefinitions>

                        <Label
                            Grid.Row="0"
                            CharacterSpacing="0.1"
                            FontFamily="Roboto-Regular"
                            FontSize="{OnPlatform Android={OnIdiom Phone=15,
                                                                   Tablet=22},
                                                  iOS=16,
                                                  WinUI=14,
                                                  MacCatalyst=16}"
                            LineBreakMode="WordWrap"
                            Text="{Binding Title}" />
                        <Label
                            Grid.Row="1"
                            CharacterSpacing="0.1"
                            FontFamily="Roboto-Regular"
                            FontSize="14"
                            LineBreakMode="WordWrap"
                            LineHeight="{OnPlatform iOS={OnIdiom Tablet=1.2,
                                                                 Default=1.025},
                                                    Default=1.2}"
                            Opacity="0.8"
                            Text="{Binding Author}" />
                        <Label
                            Grid.Row="2"
                            Margin="0,0,11,0"
                            CharacterSpacing="0.15"
                            FontFamily="Roboto-Regular"
                            FontSize="{OnPlatform Default=10,
                                                  WinUI=12,
                                                  MacCatalyst=12}"
                            Opacity="0.8"
                            Text="{Binding Size}" />
                    </Grid>
                    <Grid
                        Grid.Row="0"
                        Grid.RowSpan="1"
                        Grid.Column="2">
                        <Grid.RowDefinitions>
                            <RowDefinition Height="10" />
                            <RowDefinition Height="*" />
                            <RowDefinition Height="*" />
                        </Grid.RowDefinitions>
                        <Button
                            Grid.Row="1"
                            Command="{Binding Path=BindingContext.PlayAudioCommand, Source={x:Reference listView}}"
                            CommandParameter="{Binding .}"
                            IsVisible="{Binding IsPlayVisible}"
                            Text="&#xea15;"
                            VerticalOptions="End" />
                        <Button
                            Grid.Row="1"
                            Command="{Binding Path=BindingContext.PauseAudioCommand, Source={x:Reference listView}}"
                            CommandParameter="{Binding .}"
                            IsVisible="{Binding IsPauseVisble}"
                            Text="&#xea16;"
                            VerticalOptions="Center" />

                        <Label
                            Grid.Row="2"
                            FontSize="14"
                            HorizontalOptions="Center"
                            IsVisible="{Binding IsPauseVisble}"
                            Text="{Binding CurrentAudioPosition}"
                            TextColor="Black"
                            VerticalTextAlignment="Center" />
                    </Grid>
                    <BoxView
                        Grid.Row="1"
                        Grid.Column="1"
                        Grid.ColumnSpan="2"
                        HeightRequest="1"
                        VerticalOptions="End" />
                </Grid>
            </DataTemplate>
        </syncfusion:SfListView.ItemTemplate>
    </syncfusion:SfListView>
```

## Requirements to run the demo

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

