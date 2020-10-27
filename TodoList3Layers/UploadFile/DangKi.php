<div class="Middle">
	
    <form method="post" onsubmit="return kiemtra()" action="xulytaikhoan.php" class="DangKi">
       		 
        <div class="dangkynguoidung">
            <a><img src="images/dangky/a15ec2a159ad63ec717d1523f3b1db4d.jpg"></a>
            <h1>ĐĂNG KÝ NGƯỜI DÙNG</h1>
        </div>

        <div class="thongtincanhan">
            <div class="thongtin">
                <h3>Tên đăng nhập*</h3>
                <div><input class="test" type="text" name="username" id="UserName" size="70" placeholder="Tên đăng nhập không được có dấu và khoảng cách!!!!"></div>
            </div>
            <div class="thongtin">
                 <h3>Mật khẩu*</h3>
                 <div style="width:500px;margin:auto"><input type="password" name="password" id="MatKhau" placeholder="Tối thiểu 5 kí tự" ></div>
            </div>
            <div class="thongtin">
                 <h3>Nhập lại mật khẩu*</h3>
                 <div style="width:500px;margin:auto"><input type="password" name="re_password" id="Re-MatKhau" placeholder="**************" ></div>		
            </div>
            <div class="thongtin">
            	<h3>Email*</h3>
                <input type="email" name="email" id="email" class="test" />
            </div>
            <div class="thongtin">
                <h3>Họ và tên*</h3>
                <input type="text" name="name" id="Name" class="test" placeholder=""/>
            </div>
            <div class="thongtin">
                <h3>Ngày tháng năm sinh</h3>
                <div class="item-dk" style="padding-top:16px;">
                    <!--ngay sinh-->
                    <div class="item-ns">
                        <input type="date" name="ngaysinh" id="ngaysinh" />
                    </div>
                </div>
            </div>
            <div class="thongtin">
                <h3>Số điện thoại*</h3>
                <input type="text" name="phone" id="phone" class="test" placeholder=" ">
            </div>
            <div class="thongtin"><label>
                <input type="checkbox" name="agree" id="agree">
                <span>Tôi đã đọc và đồng ý với <a href="index.php?site=dieukhoansudung" class="dongy">Điều khoản sử dụng</a> của PetShop*</span>
            </label></div>
            <div class="Nut_Submit_Delete">
                <span style="padding-right:35px"><input type="submit" name="submit" value="Đăng ký"/></span>
                <span><input type="reset" value="Nhập lại" onclick="document.getElementById('UserName').focus();"/></span>
            </div>
        </div>
        <div class="clear"></div>
    </form>
</div>

<script type="text/javascript">
	function kiemtra()
	{
		var username= document.getElementById("UserName");
		var password=document.getElementById("MatKhau");
		var re_password= document.getElementById("Re-MatKhau");
		var name=document.getElementById("Name");
		var email= document.getElementById("email");
		var phone=document.getElementById("phone");
        var agree=document.getElementById("agree");
		
		var usernamePatt = /^[A-Za-z0-9]{5,}$/;
		var flag1 = usernamePatt.test(username.value);
		
		var passwordPatt = /\S{5,}$/;
		var flag2 = passwordPatt.test(password.value);
		

		var namePatt = /(([^0-9!@#$%^&*()\_\-\=~`+[\]{}|<>?\\,./;/:"]{2,20})\s{0,1})$/;
		var flag3 = namePatt.test(name.value);
		
		var phonePatt = /^0[1-9]\d{8}$/;
		var flag4 = phonePatt.test(phone.value);
		
		var emailPatt = /^([a-zA-Z0-9][._]?)+[^.,_;@"':<>~? ]@([a-zA-Z0-9]+([.][a-zA-Z0-9]+)+)$/;
		var flag5 = emailPatt.test(email.value);
		
		if(username.value=="")
		{
			window.alert("Chưa nhập Tên đăng nhập");
			username.focus();
			return false;
		}
		if(flag1 == false)
		{
			window.alert("Tên đăng nhập không hợp lệ, vui lòng nhập lại");
			username.focus();
			return false;
		}
		if(password.value=="")
		{
			window.alert("Chưa nhập mật khẩu ");
			password.focus();
			return false;
		}
		if(password.value.length<5)
		{
			window.alert("Mật khẩu chưa đủ 5 kí tự,vui lòng nhập lại");
			password.focus();
			return false;
		}
		if(flag2 == false)
		{
			window.alert("Mật khẩu không hợp lệ, vui lòng nhập lại");
			password.focus();
			return false;
		}
		if(password.value!=re_password.value)
		{
			window.alert("Mật khẩu bạn nhập lại đã sai,vui lòng nhập lại");
			re_password.focus();
			return false;
		}
		if(name.value=="")
		{
			window.alert("Họ và tên bạn đang để trống");
			name.focus();
			return false;
		}
		if(flag3 == false)
		{
			window.alert("Họ và tên không hợp lệ, vui lòng nhập lại");
			name.focus();
			return false;
		}
		if(phone.value=="")
		{
			window.alert("Số điện thoại bạn đang để trống");
			phone.focus();
			return false;
		}
		if(flag4 == false)
		{
			window.alert("Số điện thoại không hợp lệ, vui lòng nhập lại");
			phone.focus();
			return false;
		}
		if(flag5 == false)
		{
			window.alert("Email không hợp lệ, vui lòng nhập lại");
			email.focus();
			return false;
			
		}
        if(!agree.checked)
		{
			window.alert("Bạn chưa đồng ý Điều khoản sử dụng");
			agree.focus();
			return false;
		}
		return true;
	}
</script>
