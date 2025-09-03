# How to change the orientation rotating in WPF DataGrid?
The orientation of [WPF DataGrid](https://www.syncfusion.com/wpf-controls/datagrid)(SfDataGrid), is customized horizontally by customizing style for DataGrid, [GridCell](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.GridCell.html) and [GridHeaderCellControl](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.GridHeaderCellControl.html). DataGrid exposes properties: [CellStyle](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_CellStyle) and [HeaderStyle](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_HeaderStyle) that customizes the appearance of **GridCell** and **GridHeaderCellControl**.

To change the orientation of DataGrid horizontally by using Style, CellStyle and HeaderStyle properties you can refer the following code example.

 ```xml
 <syncfusion:SfDataGrid  x:Name="datagrid"
                         AllowSorting="True"
                         AutoGenerateColumns="False"
                         ItemsSource="{Binding Orders}"
                         NavigationMode="Row"
                         Style="{DynamicResource SfDataGridStyle}"
                         CellStyle="{DynamicResource GridCellStyle}"
                         HeaderStyle="{DynamicResource GridHeaderCellControlStyle}"
                         ColumnSizer="Star">
 ```

The following section explains you how the **DataGrid** style (SfDataGridStyle), **GridCell** style (GridCellStyle) and **GridHeaderCellControl** style (GridHeaderCellControlStyle) are customized to change the orientation of DataGrid.

DataGrid style (SfDataGridStyle) is customized to rotate its content (ScrollViewer and its panel) to 270 degree using rotate transformation. When rotating DataGrid panel ([VisualContainer](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.VisualContainer.html)), the rows become columns and columns become rows and the RowHeight & ColumnWidth remain same. Now you can change the RowHeight to ColumnWidth value and vice versa in the VisualContainer **Loaded** event.

Refer the following code example to customize the RowHeight and ColumnWidth in VisualContainer Loaded event.
 
 ```csharp
private void PART_VisualContainer_Loaded(object sender, RoutedEventArgs e)
{
   var visualcontainer = sender as VisualContainer;
   visualcontainer.RowHeights.DefaultLineSize = 150;
   visualcontainer.RowHeights[0] = 150;
   visualcontainer.ColumnWidths.DefaultLineSize = 30;
} 
 ```

Refer the following code example to rotate the DataGrid **ScrollViewer** and the panel inside it into 270 degree by customizing DataGrid style (**SfDataGridStyle**)
 
 ```xml
<Style x:Key="SfDataGridStyle" TargetType="{x:Type syncfusion:SfDataGrid}">            
     <Setter Property="Template">
       <Setter.Value>
          <ControlTemplate TargetType="{x:Type syncfusion:SfDataGrid}">
               <Grid SnapsToDevicePixels="True">
                  <Grid.RowDefinitions>
                     <RowDefinition Height="Auto"/>
                      <RowDefinition Height="*"/>
                  </Grid.RowDefinitions>
                  <Border BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" Grid.Row="1" SnapsToDevicePixels="True">
                    <ScrollViewer x:Name="PART_ScrollViewer" CanContentScroll="True" HorizontalScrollBarVisibility="{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}" IsTabStop="False" IsDeferredScrollingEnabled="{TemplateBinding ScrollViewer.IsDeferredScrollingEnabled}" PanningMode="{TemplateBinding ScrollViewer.PanningMode}" PanningRatio="{TemplateBinding ScrollViewer.PanningRatio}" VerticalScrollBarVisibility="{TemplateBinding ScrollViewer.VerticalScrollBarVisibility}" Template="{DynamicResource ScrollViewerControlTemplate}">
                       <ScrollViewer.LayoutTransform>
                          <RotateTransform Angle="270"/>
                       </ScrollViewer.LayoutTransform>
                       <syncfusion:VisualContainer x:Name="PART_VisualContainer" AllowFixedGroupCaptions="False" Background="Transparent" CanHorizontallyScroll="True" ColumnCount="0" CanVerticallyScroll="True" FrozenRows="0" FrozenColumns="0" FooterColumns="0" FooterRows="0" HorizontalPixelScroll="True" HorizontalPadding="0" RowsGenerator="{x:Null}" RowCount="0" ScrollOwner="{x:Null}" ScrollableOwner="{x:Null}" VerticalPixelScroll="True" VerticalPadding="0" Loaded="PART_VisualContainer_Loaded">
                      </syncfusion:VisualContainer>
                </ScrollViewer>
              </Border>
           </Grid>
        </ControlTemplate>
      </Setter.Value>
    </Setter>
 </Style> 
 ```

When rotating DataGrid panel into 270 degree, vertical Scrollbar is rotated to horizontal (is displayed at the top) and the horizontal Scrollbar is moved as vertical (is displayed at the right side). Now you can change the Scrollbar displayed at the top to bottom by customizing the **ScrollViewer** Style (**ScrollViewerControlTemplate**). Refer the following code example.

 ```xml
<ControlTemplate x:Key="ScrollViewerControlTemplate" TargetType="{x:Type ScrollViewer}">
        <Grid x:Name="Grid" Background="{TemplateBinding Background}">
             <Grid.ColumnDefinitions>
                <ColumnDefinition Width="Auto"/>
                <ColumnDefinition Width="*"/>                    
             </Grid.ColumnDefinitions>
             <Grid.RowDefinitions>
               <RowDefinition Height="*"/>
               <RowDefinition Height="Auto"/>
             </Grid.RowDefinitions>
             <Rectangle x:Name="Corner" Grid.Column="0" Fill="{DynamicResource {x:Static SystemColors.ControlBrushKey}}" Grid.Row="1"/>
             <ScrollContentPresenter x:Name="PART_ScrollContentPresenter" CanContentScroll="{TemplateBinding CanContentScroll}" CanHorizontallyScroll="False" CanVerticallyScroll="False" ContentTemplate="{TemplateBinding ContentTemplate}" Content="{TemplateBinding Content}" Grid.Column="1" Margin="{TemplateBinding Padding}" Grid.Row="0"/>
            <ScrollBar x:Name="PART_VerticalScrollBar"  AutomationProperties.AutomationId="VerticalScrollBar" 
  Cursor="Arrow" Grid.Column="0" Maximum="{TemplateBinding ScrollableHeight}" 
  Minimum="0" Grid.Row="0" Visibility="{TemplateBinding ComputedVerticalScrollBarVisibility}" 
  Value="{Binding VerticalOffset, Mode=OneWay, RelativeSource={RelativeSource TemplatedParent}}" 
  ViewportSize="{TemplateBinding ViewportHeight}"/>
           <ScrollBar x:Name="PART_HorizontalScrollBar" AutomationProperties.AutomationId="HorizontalScrollBar" Cursor="Arrow" Grid.Column="0" Maximum="{TemplateBinding ScrollableWidth}" Minimum="0" Orientation="Horizontal" Grid.Row="1" 
  Visibility="{TemplateBinding ComputedHorizontalScrollBarVisibility}" 
  Value="{Binding HorizontalOffset, Mode=OneWay, RelativeSource={RelativeSource TemplatedParent}}" 
  ViewportSize="{TemplateBinding ViewportWidth}"/>
      </Grid>
</ControlTemplate> 
 ```
When rotating DataGrid panel into 270 degree, **GridCell** content changed as Vertical. To display the cell content’s horizontally, you can rotate the GridCell content into 90 degree using rotate transformation by customizing GridCell style (GridCellStyle). Refer the following code example to rotate the GridCell content by customizing GridCell style (**GridCellStyle**).

 ```xml
 <ControlTemplate x:Key="ValidationToolTipTemplate">
     <Grid x:Name="Root"
       Margin="5,0"
       Opacity="0"
       RenderTransformOrigin="0,0">
         <Grid.RenderTransform>
             <TranslateTransform x:Name="xform" X="-25" />
         </Grid.RenderTransform>
         <VisualStateManager.VisualStateGroups>
             <VisualStateGroup Name="OpenStates">
                 <VisualStateGroup.Transitions>
                     <VisualTransition GeneratedDuration="0" />
                     <VisualTransition GeneratedDuration="0:0:0.2" To="Open">
                         <Storyboard>
                             <DoubleAnimation Duration="0:0:0.2"
                                          Storyboard.TargetName="xform"
                                          Storyboard.TargetProperty="X"
                                          To="0">
                                 <DoubleAnimation.EasingFunction>
                                     <BackEase Amplitude=".3" EasingMode="EaseOut" />
                                 </DoubleAnimation.EasingFunction>
                             </DoubleAnimation>
                             <DoubleAnimation Duration="0:0:0.2"
                                          Storyboard.TargetName="Root"
                                          Storyboard.TargetProperty="Opacity"
                                          To="1" />
                         </Storyboard>
                     </VisualTransition>
                 </VisualStateGroup.Transitions>
                 <VisualState x:Name="Closed">
                     <Storyboard>
                         <DoubleAnimation Duration="0"
                                      Storyboard.TargetName="Root"
                                      Storyboard.TargetProperty="Opacity"
                                      To="0" />
                     </Storyboard>
                 </VisualState>
                 <VisualState x:Name="Open">
                     <Storyboard>
                         <DoubleAnimation Duration="0"
                                      Storyboard.TargetName="xform"
                                      Storyboard.TargetProperty="X"
                                      To="0" />
                         <DoubleAnimation Duration="0"
                                      Storyboard.TargetName="Root"
                                      Storyboard.TargetProperty="Opacity"
                                      To="1" />
                     </Storyboard>
                 </VisualState>
             </VisualStateGroup>
         </VisualStateManager.VisualStateGroups>

         <Border Margin="4,4,-4,-4"
             Background="#052A2E31"
             CornerRadius="5" />
         <Border Margin="3,3,-3,-3"
             Background="#152A2E31"
             CornerRadius="4" />
         <Border Margin="2,2,-2,-2"
             Background="#252A2E31"
             CornerRadius="3" />
         <Border Margin="1,1,-1,-1"
             Background="#352A2E31"
             CornerRadius="2" />

         <Border Background="#FFDC000C" CornerRadius="2" />
         <Border CornerRadius="2">
             <TextBlock MaxWidth="250"
                    Margin="8,4,8,4"
                    Foreground="White"
                    Text="{TemplateBinding Tag}"
                    TextWrapping="Wrap"
                    UseLayoutRounding="false" />
         </Border>
     </Grid>
 </ControlTemplate>

 <Style x:Key="GridCellStyle" TargetType="syncfusion:GridCell">
     <Setter Property="Background" Value="Transparent" />
     <Setter Property="BorderBrush" Value="Gray" />
     <Setter Property="BorderThickness" Value="0,0,1,1" />
     <Setter Property="Padding" Value="0,0,0,0" />
     <Setter Property="FocusVisualStyle" Value="{x:Null}" />
     <Setter Property="IsTabStop" Value="False" />
     <Setter Property="VerticalContentAlignment" Value="Center"/>
     <Setter Property="Template">
         <Setter.Value>
             <ControlTemplate TargetType="syncfusion:GridCell">
                 <Grid SnapsToDevicePixels="True">
                     <VisualStateManager.VisualStateGroups>
                         <VisualStateGroup x:Name="IndicationStates">
                             <VisualState x:Name="NoError">
                                 <Storyboard BeginTime="0">
                                     <!--<DoubleAnimationUsingKeyFrames Storyboard.TargetName="PART_InValidCellBorder" Storyboard.TargetProperty="Width">
                                     <EasingDoubleKeyFrame KeyTime="0" Value="1" />
                                     <EasingDoubleKeyFrame KeyTime="0" Value="0" />
                                 </DoubleAnimationUsingKeyFrames>-->
                                     <ObjectAnimationUsingKeyFrames BeginTime="00:00:00"
                                                                Storyboard.TargetName="PART_InValidCellBorder"
                                                                Storyboard.TargetProperty="(UIElement.Visibility)">
                                         <DiscreteObjectKeyFrame KeyTime="00:00:00" Value="{x:Static Visibility.Collapsed}" />
                                     </ObjectAnimationUsingKeyFrames>
                                 </Storyboard>
                             </VisualState>
                             <VisualState x:Name="HasError">
                                 <Storyboard>
                                     <!--<DoubleAnimationUsingKeyFrames Storyboard.TargetName="PART_InValidCellBorder" Storyboard.TargetProperty="Width">
                                     <EasingDoubleKeyFrame KeyTime="0" Value="0" />
                                     <EasingDoubleKeyFrame KeyTime="0" Value="10" />
                                 </DoubleAnimationUsingKeyFrames>-->
                                     <ObjectAnimationUsingKeyFrames BeginTime="00:00:00"
                                                                Storyboard.TargetName="PART_InValidCellBorder"
                                                                Storyboard.TargetProperty="(UIElement.Visibility)">
                                         <DiscreteObjectKeyFrame KeyTime="00:00:00" Value="{x:Static Visibility.Visible}" />
                                     </ObjectAnimationUsingKeyFrames>
                                 </Storyboard>
                             </VisualState>

                         </VisualStateGroup>
                         <VisualStateGroup x:Name="BorderStates">
                             <VisualState x:Name="NormalCell" />
                             <VisualState x:Name="FrozenColumnCell"/>
                             <VisualState x:Name="FooterColumnCell">
                                 <Storyboard BeginTime="0">
                                     <ThicknessAnimationUsingKeyFrames BeginTime="0"
                                                                   Duration="1"
                                                                   Storyboard.TargetName="PART_GridCellBorder"
                                                                   Storyboard.TargetProperty="BorderThickness">
                                         <EasingThicknessKeyFrame KeyTime="0" Value="1,0,1,1" />
                                     </ThicknessAnimationUsingKeyFrames>
                                 </Storyboard>
                             </VisualState>
                             <VisualState x:Name="BeforeFooterColumnCell">
                                 <Storyboard BeginTime="0">
                                     <ThicknessAnimationUsingKeyFrames BeginTime="0"
                                                                   Duration="1"
                                                                   Storyboard.TargetName="PART_GridCellBorder"
                                                                   Storyboard.TargetProperty="BorderThickness">
                                         <EasingThicknessKeyFrame KeyTime="0" Value="0,0,0,1" />
                                     </ThicknessAnimationUsingKeyFrames>
                                 </Storyboard>
                             </VisualState>
                         </VisualStateGroup>
                     </VisualStateManager.VisualStateGroups>
                     <Border Background="{TemplateBinding CellSelectionBrush}"
                         SnapsToDevicePixels="True"
                         Visibility="{TemplateBinding SelectionBorderVisibility}" />

                     <Border x:Name="PART_GridCellBorder"
                         Background="{TemplateBinding Background}"
                         BorderBrush="{TemplateBinding BorderBrush}"
                         BorderThickness="{TemplateBinding BorderThickness}"
                         SnapsToDevicePixels="True">
                         <Grid>
                             <Grid.LayoutTransform>
                                 <RotateTransform Angle="90"/>
                             </Grid.LayoutTransform>
                             <ContentPresenter Margin="{TemplateBinding Padding}" Opacity="{TemplateBinding AnimationOpacity}" />
                         </Grid>
                     </Border>

                     <Border Margin="0,0,1,1"
                         Background="Transparent"
                         BorderBrush="{TemplateBinding CurrentCellBorderBrush}"
                         BorderThickness="{TemplateBinding CurrentCellBorderThickness}"
                         IsHitTestVisible="False"
                         SnapsToDevicePixels="True"
                         Visibility="{TemplateBinding CurrentCellBorderVisibility}" />
                     <Border x:Name="PART_InValidCellBorder"
                         Width="10"
                         Height="10"
                         HorizontalAlignment="Right"
                         VerticalAlignment="Top"
                         SnapsToDevicePixels="True"
                         Visibility="Collapsed">
                         <ToolTipService.ToolTip>
                             <ToolTip Background="#FFDB000C"
                                  Placement="Right"
                                  PlacementRectangle="20,0,0,0"
                                  Tag="{TemplateBinding ErrorMessage}"
                                  Template="{StaticResource ValidationToolTipTemplate}" />
                         </ToolTipService.ToolTip>
                         <Path Data="M0.5,0.5 L12.652698,0.5 12.652698,12.068006 z"
                           Fill="Yellow"
                           SnapsToDevicePixels="True"
                           Stretch="Fill" />
                     </Border>
                 </Grid>
             </ControlTemplate>
         </Setter.Value>
     </Setter>
 </Style>
 ```

Like the GridCell, you can rotate the **GridHeaderCellControl** content into 90 degree using rotate transformation by customizing GridHeaderCellControl style (**GridHeaderCellControlStyle**) as follows.
 
 ```xml
 <Style x:Key="GridHeaderCellControlStyle" TargetType="{x:Type syncfusion:GridHeaderCellControl}">
     <Setter Property="BorderThickness" Value="0,1,1,0"/>
     <Setter Property="Template">
         <Setter.Value>
             <ControlTemplate TargetType="{x:Type syncfusion:GridHeaderCellControl}">
                 <Grid>
                     <Grid.LayoutTransform>
                         <RotateTransform Angle="90"/>
                     </Grid.LayoutTransform>
                     <Border x:Name="PART_HeaderCellBorder" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" SnapsToDevicePixels="True">
                         <Grid Margin="{TemplateBinding Padding}" SnapsToDevicePixels="True">
                             <Grid.ColumnDefinitions>
                                 <ColumnDefinition Width="*"/>
                                 <ColumnDefinition Width="Auto"/>
                             </Grid.ColumnDefinitions>
                             <ContentPresenter ContentTemplate="{TemplateBinding ContentTemplate}" Content="{TemplateBinding Content}" ContentStringFormat="{TemplateBinding ContentStringFormat}" Focusable="False" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" VerticalAlignment="Center"/>
                             <Grid x:Name="PART_SortButtonPresenter" Grid.Column="1" SnapsToDevicePixels="True">
                                 <Grid.ColumnDefinitions>
                                     <ColumnDefinition Width="0">
                                         <ColumnDefinition.MinWidth>
                                             <Binding Mode="OneWay" Path="SortDirection" RelativeSource="{RelativeSource TemplatedParent}">
                                                 <Binding.Converter>
                                                     <syncfusion:SortDirectionToWidthConverter/>
                                                 </Binding.Converter>
                                             </Binding>
                                         </ColumnDefinition.MinWidth>
                                     </ColumnDefinition>
                                     <ColumnDefinition Width="*"/>
                                 </Grid.ColumnDefinitions>
                                 <Path Data="F1M753.644,-13.0589L753.736,-12.9639 753.557,-12.7816 732.137,8.63641 732.137,29.7119 756.445,5.40851 764.094,-2.24384 764.275,-2.42352 771.834,5.1286 796.137,29.4372 796.137,8.36163 774.722,-13.0589 764.181,-23.5967 753.644,-13.0589z" Fill="Gray" HorizontalAlignment="Center" Height=
                                     <Path.RenderTransform>
                                         <TransformGroup>
                                             <RotateTransform Angle="90"/>
                                             <ScaleTransform ScaleY="1" ScaleX="1"/>
                                         </TransformGroup>
                                     </Path.RenderTransform>
                                     <Path.Visibility>
                                         <Binding ConverterParameter="Ascending" Path="SortDirection" RelativeSource="{RelativeSource TemplatedParent}">
                                             <Binding.Converter>
                                                 <syncfusion:SortDirectionToVisibilityConverter/>
                                             </Binding.Converter>
                                         </Binding>
                                     </Path.Visibility>
                                 </Path>
                                 <Path Data="F1M181.297,177.841L181.205,177.746 181.385,177.563 202.804,156.146 202.804,135.07 178.497,159.373 170.847,167.026 170.666,167.205 163.107,159.653 138.804,135.345 138.804,156.42 160.219,177.841 170.76,188.379 181.297,177.841z" Fill="Gray" HorizontalAlignment="Center" Height="8.138" St
                                     <Path.RenderTransform>
                                         <TransformGroup>
                                             <RotateTransform Angle="90"/>
                                             <ScaleTransform ScaleY="1" ScaleX="1"/>
                                         </TransformGroup>
                                     </Path.RenderTransform>
                                     <Path.Visibility>
                                         <Binding ConverterParameter="Decending" Path="SortDirection" RelativeSource="{RelativeSource TemplatedParent}">
                                             <Binding.Converter>
                                                 <syncfusion:SortDirectionToVisibilityConverter/>
                                             </Binding.Converter>
                                         </Binding>
                                     </Path.Visibility>
                                 </Path>
                                 <TextBlock Grid.Column="1" Foreground="{TemplateBinding Foreground}" FontSize="10" Margin="0,-4,0,0" SnapsToDevicePixels="True" Text="{TemplateBinding SortNumber}" Visibility="{TemplateBinding SortNumberVisibility}" VerticalAlignment="Center"/>
                             </Grid>
                         </Grid>
                     </Border>
                 </Grid>
             </ControlTemplate>
         </Setter.Value>
     </Setter>
 </Style>
 ```
Refer the following screenshot where the orientation of DataGrid is changed (Column is displayed at the left side instead of top and records are displayed horizontally instead of vertically).

 ![ChangingOrientationOfColumnsRows](https://support.syncfusion.com/kb/agent/attachment/article/3003/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjQyMDAzIiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.xftVDW2XTPRoIEpW0rie2HPFvwQnP0vANzFFR_KzDs4)

Take a moment to peruse the [WPF - DataGrid styles and templates](https://help.syncfusion.com/wpf/datagrid/styles-and-templates), to learn more about DataGrid Selections with examples.
