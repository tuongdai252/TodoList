<?php
    require 'DataProvider.php';
    require 'ProductsPerPage.inc';
?>

<div>
    <h1 class="title-background">
        <span class="title">
            <?php
            $title = "Sản phẩm cho cá";
            if(isset($_GET['menu']))
            {
                if($_GET['menu'] == 1)
                    $title = "Thức ăn cho cá";
                if($_GET['menu'] == 2)
                    $title = "Vật dụng cho cá";
                if($_GET['menu'] == 3)
                    $title = "Bể cá";
            }
            echo $title;
            ?>
        </span>
        <?php
            if (isset($_GET['pricefrom']) && isset($_GET['priceto'])) {
                echo '<span class="title-price">';
                $titleprice = "";
                $giatu = $_GET['pricefrom'];
                $giaden = $_GET['priceto'];

                $format_giatu = number_format(floatval($giatu), 0, ',', '.');
                $format_giaden = number_format(floatval($giaden), 0, ',', '.');

                if ($giatu != "" && $giaden == "") {
                    $titleprice = " | Giá từ " . $format_giatu . " đ";
                }
                if ($giaden != "" && $giatu == "") {
                    $titleprice = " | Giá đến " . $format_giaden . " đ";
                }
                if ($giatu != "" && $giaden != "") {
                    $titleprice = " | Giá từ " . $format_giatu . 'đ <i class="fas fa-arrow-right"></i> ' . $format_giaden . "đ";
                }
                echo $titleprice . "</span>";
            }
        ?>
    </h1>
     <div class="container">
         <div id="sp">
             <?php
                $sql = "SELECT sp.*, sdt.madv, sdt.matl, km.giakhuyenmai FROM sanpham as sp JOIN sp_dv_tl as sdt ON sp.masp = sdt.masp LEFT JOIN spkhuyenmai AS km ON sp.masp = km.masp WHERE xoa=0 AND madv='fish'";
                if (isset($_GET['menu']))
                {
                    if($_GET['menu'] == 0)
                        $sql = $sql;
                    if($_GET['menu'] == 1)
                        $sql = $sql . " AND matl='food'";
                    if($_GET['menu'] == 2)
                        $sql = $sql . " AND matl='stuff'";
                    if($_GET['menu'] == 3)
                        $sql = $sql . " AND matl='bed'";
                }
                if (isset($_GET['pricefrom']) && isset($_GET['priceto'])) {
                    $giatu = $_GET['pricefrom'];
                    $giaden = $_GET['priceto'];
                    if ($giatu != "" && $giaden == "")
                        $sql = $sql . " AND sp.giatien >= " . $giatu;
                    if ($giaden != "" && $giatu == "")
                        $sql = $sql . " AND sp.giatien <= " . $giaden;
                    if ($giatu != "" && $giaden != "")
                        $sql = $sql . " AND (sp.giatien BETWEEN " . $giatu . " AND " . $giaden . ")";
                }

                $sql = $sql . " LIMIT $offset, $productsPerPage";
                $result = DataProvider::executeQuery($sql);
                $dem=0;

                while ($row = mysqli_fetch_array($result))
                {
                    echo "<form class='form_sp'>";
                    echo "<div class='sanpham'>";
                    echo "  <a href='index.php?site=SanPham&masp=".$row["masp"]."' class='p-img'><img src='images/sanpham/". $row["hinhanh"] ."'  onerror=\"this.src='../images/sanpham/No_image_available.png'\" /></a>";
                    echo "  <a href='index.php?site=SanPham&masp=".$row["masp"]."' class='p-name'>". $row["tensp"] ."</a>";
                    if($row["giakhuyenmai"] === NULL){
                        echo "  <p class='gia'>". number_format($row["giatien"], 0, ',', '.') ."đ</p>";
                    }
                    else
                    {
                        echo "  <p class='gia'>";
                        echo "  "   . number_format($row["giakhuyenmai"], 0, ',', '.') ."đ";
                        echo "      <span class='giacu'>". number_format($row["giatien"], 0, ',', '.') ."đ</span>";
                        echo "  </p>";
                    }
                    if($row["soluong"] == 0){
                        echo "  <p><button class='shop-item-button hethang' disabled>Tạm hết hàng</button></p>";
                    }
                    else{
                        echo "<p><input name='masp' type='hidden' value='". $row["masp"] ."'>";
                        echo "<input name='soluong' type='hidden' value='1'>";
                        echo "<button type='submit' class='shop-item-button'>";
                        echo        "Đặt mua ngay";
                        echo "</button></p>";
                    }
                    echo "</div>";
                    echo "</form>";
                    $dem=$dem+1;
                }
                if ($dem == 0) {
                    echo "<center>";
                    echo "     <img src='images/background/nofound.png'>";
                    echo "     <span>";
                    echo "         <br><strong>Ôi không!</strong><br>";
                    echo "         Có vẻ như chú chó này đã lấy mất tất cả sản phẩm bạn mà tìm kiếm.<br>";
                    echo "         Trừ khi bạn đang tìm kiếm chú chó đáng yêu này. Chúc mừng! Bạn đã tìm thấy nó.<br>";
                    echo "     </span>";
                    echo "</center>";
                }
            ?>
         </div>
         <div class="clear"></div>
         
         <?php
	if($dem != 0)
            include('pagination.php');
         ?>
         
         <div class="clear"></div>
     </div>
</div>
<div class="clear"></div>